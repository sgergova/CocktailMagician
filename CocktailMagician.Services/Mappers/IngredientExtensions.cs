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
                CocktailIngredients = entity.CocktailIngredients.GetDTOs(),
                Description = entity.Description,
                Quantity = entity.Quantity,
                Rating = entity.Rating,
            };
        }

        public static ICollection<IngredientDTO> GetDTOs(this ICollection<Ingredient> entities)
        {
            return entities.Select(GetDTO).ToList();
        }
    }
}
