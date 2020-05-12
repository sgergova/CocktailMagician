using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
   public class CocktailService
    {
        private readonly CMContext context;

        public CocktailService(CMContext context)
        {
            this.context = context;
        }

        public async Task<CocktailDTO> Get(Guid id)
        {
            var entity = await this.context.Cocktails
                                    .Include(c=>c.Ingredients)
                                    .Include(c=>c.Bars)
                                    .Include(c=>c.Comments)
                                    .Include(c=>c.Stars)
                                    .FirstOrDefaultAsync(b =>b.IsDeleted==false && b.Id == id)
                                    ?? throw new ArgumentNullException("The value cannot be null.");

            return entity.Map();

        }

        public async Task<ICollection<CocktailDTO>> GetAll()
        {
            var entities = await this.context.Cocktails
                                    .Where(c => c.IsDeleted == false)
                                    .Include(c => c.Ingredients)
                                    .Include(c => c.Bars)
                                    .Include(c => c.Comments)
                                    .Include(c => c.Stars)
                                    .ToListAsync()
                                    ?? throw new ArgumentNullException("The value cannot be null.");

            return entities.Map();
        }

        public async Task<CocktailDTO> Create(CocktailDTO cocktailDTO)
        {
            if (this.context.Bars.Any(b => b.Name == cocktailDTO.Name))
                throw new ArgumentException("The name is already existing");

            if (cocktailDTO.Name == null)
                throw new ArgumentNullException("The name is mandatory");

            var cocktail = new Cocktail
            {
                Id = cocktailDTO.Id,
                AlcoholPercentage = cocktailDTO.AlcoholPercentage,
                Bars = cocktailDTO.Bars,
                Comments = cocktailDTO.Comments,
                ImageURL = cocktailDTO.ImageURL,
                Ingredients = cocktailDTO.Ingredients,
                IsAlcoholic = cocktailDTO.IsAlcoholic,
                Name = cocktailDTO.Name,
                Rating = cocktailDTO.Rating,
                Stars = cocktailDTO.Stars
            };

            await context.Cocktails.AddAsync(cocktail);
            await context.SaveChangesAsync();


            return cocktail.Map();
        }

        public async Task<CocktailDTO> Update(CocktailDTO cocktailToUpdate)
        {
            var cocktailDTO = await Get(cocktailToUpdate.Id);

            var cocktail = cocktailDTO.Map();

            cocktail.Name = cocktailToUpdate.Name;
            cocktail.AlcoholPercentage = cocktailToUpdate.AlcoholPercentage;
            cocktail.IsAlcoholic = cocktailToUpdate.IsAlcoholic;
            cocktail.ImageURL = cocktailToUpdate.ImageURL;

            this.context.Update(cocktail);

            await this.context.SaveChangesAsync();

            return cocktail.Map();
        }
        public async Task<CocktailDTO> Delete(Guid? id)
        {
            var cocktailToDelete = await this.context.Cocktails
                                 .FirstOrDefaultAsync(b => b.Id == id && b.IsDeleted == false)
                                 ?? throw new ArgumentNullException();

            cocktailToDelete.IsDeleted = true;
            cocktailToDelete.ModifiedOn = DateTime.UtcNow;
                context.Cocktails.Update(cocktailToDelete);
                await context.SaveChangesAsync();
            

            return cocktailToDelete.Map();
        }
    }
}
