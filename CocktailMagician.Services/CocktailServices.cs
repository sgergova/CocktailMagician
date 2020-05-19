using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class CocktailServices : ICocktailServices
    {
        private readonly CMContext context;

        public CocktailServices(CMContext context)
        {
            this.context = context;
        }

        public async Task<CocktailDTO> GetCocktail(Guid id)
        {

            var entity = await GetCocktailsQueryable()
                                       .FirstOrDefaultAsync(b => b.Id == id)
                                       ?? throw new ArgumentNullException();

            return entity.GetDTO();

        }

        public async Task<ICollection<CocktailDTO>> GetAllCocktails(string name, ICollection<CocktailIngredient> ingredients
            , int? rating)
        {
            var cocktails = GetCocktailsQueryable();
            
            if (name!=null)
            {
                cocktails = cocktails.Where(c => c.Name.ToLower().Contains( name.ToLower()));
            }
            if (ingredients!=null)
            {
                foreach (var item in ingredients)
                {
                    cocktails = cocktails.Where(c => c.CocktailIngredients.Contains(item));
                }
            }
            if (rating!=null)
            {
                cocktails = cocktails.Where(c => c.Rating == rating);
            }
            var returnCocktails = await cocktails.ToListAsync();
            return returnCocktails.GetDTOs();
        }

        public async Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailDTO)
        {
            if (this.context.Bars.Any(b => b.Name == cocktailDTO.Name))
                throw new ArgumentException("The name is already existing");

            if (cocktailDTO.Name == null)
                throw new ArgumentNullException("The name is mandatory");


            var cocktail = new Cocktail
            {
                Id = cocktailDTO.Id,
                AlcoholPercentage = cocktailDTO.AlcoholPercentage,
                Bars = cocktailDTO.GetEntity().Bars,
                Comments = cocktailDTO.Comments,
                ImageURL = cocktailDTO.ImageURL,
                CocktailIngredients = cocktailDTO.Ingredients.GetEntities(),
                IsAlcoholic = cocktailDTO.IsAlcoholic,
                Name = cocktailDTO.Name,
                Rating = cocktailDTO.Rating,
                CreatedOn = DateTime.UtcNow

            };

            await context.Cocktails.AddAsync(cocktail);
            await context.SaveChangesAsync();

            return cocktail.GetDTO();

        }

        public async Task<CocktailDTO> AddIngredientToCocktail(Guid cocktailId, Guid ingredientId)
        {
            var cocktail = await this.context.Cocktails
                                             .Where(c=>c.IsDeleted == false)
                                             .FirstOrDefaultAsync(c => c.Id == cocktailId);

            var ingredient = await this.context.Ingredients
                                           .Where(c => c.IsDeleted == false)
                                           .FirstOrDefaultAsync(c => c.Id == ingredientId);

            var cocktailIngredient = await this.context.CocktailIngredients
                                                 .FirstOrDefaultAsync(ci=>ci.IngredientId == ingredientId 
                                                 && ci.CocktailId == cocktailId);
            if (cocktailIngredient != null)
            {
                var newCocktailIngredient = new CocktailIngredient
                {
                    CocktailId = cocktail.Id,
                    IngredientId = ingredientId
                };

                cocktail.CocktailIngredients.Add(newCocktailIngredient);
                ingredient.CocktailIngredients.Add(newCocktailIngredient);

                await this.context.CocktailIngredients.AddAsync(newCocktailIngredient);
                this.context.Cocktails.Update(cocktail);
                this.context.Ingredients.Update(ingredient);
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"{ingredient} is already part of {cocktail}");
            }

            return cocktail.GetDTO();

        }
        public async Task<ICollection<CocktailDTO>> SearchByAlcohol(string criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("You should enter your criteria");
            
            var cocktails = this.context.Cocktails
                                            .Where(c=>c.IsDeleted == false)
                                            .AsQueryable();

          
            if (criteria == "non-alcoholic")
                cocktails = cocktails.Where(c => c.IsAlcoholic == false);

            if (criteria == "alcoholic")
                cocktails = cocktails.Where(c => c.IsAlcoholic == true);
           


            var cocktailsToReturn = await cocktails.ToListAsync();
            return cocktailsToReturn.GetDTOs();
        }


       


        public async Task<CocktailDTO> RemoveIngredientFromCocktail(Guid cocktailId, Guid ingredientId)
        {
            var ingredient = await this.context.CocktailIngredients
                                               .Where(i=>i.IsDeleted == false)
                                               .FirstOrDefaultAsync(i => i.Id == ingredientId);

            var cocktail = await GetCocktailsQueryable()
                                          .FirstOrDefaultAsync(c => c.Id == cocktailId);

            var cocktailIngredient = await this.context.CocktailIngredients
                                       .FirstOrDefaultAsync(ci => ci.IngredientId == ingredientId && ci.CocktailId == cocktailId)
                                       ?? throw new ArgumentNullException();


            cocktailIngredient.ModifiedOn = DateTime.UtcNow;
            cocktail.CocktailIngredients.Remove(cocktailIngredient);


            this.context.Cocktails.Update(cocktail);
            this.context.CocktailIngredients.Update(cocktailIngredient);
            await this.context.SaveChangesAsync();

            return cocktail.GetDTO();
        }

        public async Task<CocktailDTO> UpdateCocktail(CocktailDTO cocktailToUpdate)
        {
            var cocktailDTO = await GetCocktail(cocktailToUpdate.Id);

            var cocktail = cocktailDTO.GetEntity();

            cocktail.Name = cocktailToUpdate.Name;
            cocktail.AlcoholPercentage = cocktailToUpdate.AlcoholPercentage;
            cocktail.IsAlcoholic = cocktailToUpdate.IsAlcoholic;
            cocktail.ImageURL = cocktailToUpdate.ImageURL;
            cocktail.ModifiedOn = DateTime.UtcNow;


            this.context.Cocktails.Update(cocktail);
            await this.context.SaveChangesAsync();

            return cocktail.GetDTO();
        }
        public async Task<CocktailDTO> DeleteCocktail(Guid id)
        {
            var cocktailToDelete = await GetCocktailsQueryable()
                                 .FirstOrDefaultAsync(b => b.Id == id);

            if (cocktailToDelete.Bars.Any(b => !b.IsDeleted == true))
            {
                cocktailToDelete.IsDeleted = true;
                cocktailToDelete.DeletedOn = DateTime.UtcNow;
                context.Cocktails.Update(cocktailToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"There is a bar that offers {cocktailToDelete}");
            }

            return cocktailToDelete.GetDTO();
        }

        private IQueryable<Cocktail> GetCocktailsQueryable()
        {
            var cocktails = this.context.Cocktails
                                    .Where(c => c.IsDeleted == false)
                                    ?? throw new ArgumentNullException("Value cannot be null");

            return cocktails;
        }

      
    }
}
