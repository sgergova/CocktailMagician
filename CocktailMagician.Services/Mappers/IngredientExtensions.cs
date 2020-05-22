using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CocktailMagician.Services.Mappers
{
    public static class IngredientExtensions
    {
        public static IngredientDTO GetDTO(this Ingredient entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity not found");

            return new IngredientDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                CocktailIngredients = entity.CocktailIngredients?.GetDTOs(),
                Description = entity.Description,
                Quantity = entity.Quantity,
                Rating = entity.Rating,
                IsDeleted = entity.IsDeleted,
                ModifiedOn = entity.ModifiedOn,
                IsAlcoholic = entity.IsAlcoholic,
                DeletedOn = entity.DeletedOn,
                
            };
        }

        public static ICollection<IngredientDTO> GetDTOs(this ICollection<Ingredient> entities)
        {
            return entities.Select(GetDTO).ToList();
        }

        public static Ingredient GetEntity(this IngredientDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity not found");

            return new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = entity.Name,
                CocktailIngredients = entity.CocktailIngredients?.GetEntities(),
                Description = entity.Description,
                Quantity = entity.Quantity,
                Rating = entity.Rating,
                IsAlcoholic = entity.IsAlcoholic,
                CreatedOn = DateTime.UtcNow
            };
        }

        public static ICollection<Ingredient> GetEntities(this ICollection<IngredientDTO> entities)
        {
            return entities.Select(GetEntity).ToList();
        }
    }
}
