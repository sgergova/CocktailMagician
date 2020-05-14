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
            if (id == null)
                throw new ArgumentNullException("The ID cannot be null");


            var entity = await GetCocktailsQueryable()
                                        .FirstOrDefaultAsync(b => b.Id == id);


            return entity.GetDTO();

        }

        public async Task<ICollection<CocktailDTO>> GetAllCocktails()
        {
            var entities = await GetCocktailsQueryable()
                                            .ToListAsync();


            return entities.GetDTOs();
        }

        public async Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailDTO)
        {
            if (this.context.Bars.Any(b => b.Name == cocktailDTO.Name))
                throw new ArgumentException("The name is already existing");

            if (cocktailDTO.Name == null)
                throw new ArgumentNullException("The name is mandatory");
            var cocktail = cocktailDTO.GetEntity();

            await context.Cocktails.AddAsync(cocktail);
            await context.SaveChangesAsync();


            return cocktail.GetDTO();
            //var cocktail = new Cocktail
            //{
            //    Id = cocktailDTO.Id,
            //    AlcoholPercentage = cocktailDTO.AlcoholPercentage,
            //    Bars = cocktailDTO.Bars,
            //    Comments = cocktailDTO.Comments,
            //    ImageURL = cocktailDTO.ImageURL,
            //    CocktailIngredients = cocktailDTO.Ingredients,
            //    IsAlcoholic = cocktailDTO.IsAlcoholic,
            //    Name = cocktailDTO.Name,
            //    Rating = cocktailDTO.Rating,
            //};
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
