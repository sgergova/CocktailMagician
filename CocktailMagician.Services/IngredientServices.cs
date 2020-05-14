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
    public class IngredientServices :IIngredientServices
    {
        private readonly CMContext context;

        public IngredientServices(CMContext context)
        {
            this.context = context;
        }
        public async Task<IngredientDTO> GetIngredient(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException("The ID cannot be null");


            var entity = await GetAllQueryable()
                                        .FirstOrDefaultAsync(b => b.Id == id);


            return entity.GetDTO();

        }
        public async Task<ICollection<IngredientDTO>> GetAllIngredients()
        {
            var entities = await GetAllQueryable()
                                                    .ToListAsync();

            return entities.GetDTOs();
        }

        public async Task<IngredientDTO> CreateIngredient(IngredientDTO ingredientDTO)
        {
            if (this.context.Bars.Any(b => b.Name == ingredientDTO.Name))
                throw new ArgumentException("The name is already existing");

            if (ingredientDTO.Name == null)
                throw new ArgumentNullException("The name is mandatory");

            var ingredient = ingredientDTO.GetEntity();
            await context.Ingredients.AddAsync(ingredient);
            await context.SaveChangesAsync();

            return ingredient.GetDTO();
            //var ingredient = new Ingredient
            //{
            //    Name = ingredientDTO.Name,
            //    CocktailIngredients = ingredientDTO.CocktailIngredients,
            //    Description = ingredientDTO.Description,
            //    Quantity = ingredientDTO.Quantity,
            //    CreatedOn = DateTime.UtcNow,
            //};
        }

        public async Task<IngredientDTO> UpdateIngredient(IngredientDTO ingredientDTO)
        {
            if (ingredientDTO.Id == null)
                throw new ArgumentNullException("Value cannot be null.");

            var ingredientToUpdate = await GetIngredient(ingredientDTO.Id);
            var ingredient = ingredientToUpdate.GetEntity();

            ingredient.Name = ingredientDTO.Name;
            ingredient.CocktailIngredients = ingredientDTO.CocktailIngredients;
            ingredient.Quantity = ingredientDTO.Quantity;
            ingredient.Description = ingredientDTO.Description;
            ingredient.ModifiedOn = DateTime.UtcNow;

            this.context.Ingredients.Update(ingredient);
            await this.context.SaveChangesAsync();

            return ingredient.GetDTO();

        }

        public async Task<IngredientDTO> DeleteIngredient(Guid id)
        {
            var ingredientsToDelete = await GetAllQueryable()
                                 .Include(i=>i.CocktailIngredients)
                                 .FirstOrDefaultAsync(b => b.Id == id)
                                 ?? throw new ArgumentNullException();


            if (ingredientsToDelete.CocktailIngredients.Any(c => c.IsDeleted == true))
            {
                ingredientsToDelete.IsDeleted = true;
                ingredientsToDelete.DeletedOn = DateTime.UtcNow;
                context.Ingredients.Update(ingredientsToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Cannot delete {ingredientsToDelete}" +
                    $"There are cocktails available.");
            }

            return ingredientsToDelete.GetDTO();
        }

        private IQueryable<Ingredient> GetAllQueryable()
        {
            var entities = this.context.Ingredients
                                       .Where(b => b.IsDeleted == false)
                                       ?? throw new ArgumentNullException("The value cannot be null");

            return entities;
        }
    }
}
