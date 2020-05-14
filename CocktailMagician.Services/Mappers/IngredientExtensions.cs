using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                CocktailIngredients = entity.CocktailIngredients,
                Description = entity.Description,
                Quantity = entity.Quantity,
                Rating = entity.Rating,
            };
        }

        public static ICollection<IngredientDTO> GetDTOs(this ICollection<Ingredient> entities)
        {
            return entities.Select(GetDTO).ToList();
        }
        public static Ingredient GetEntity(this IngredientDTO ingredientDTO)
        {
            if (ingredientDTO == null)
                throw new ArgumentNullException();

            return new Ingredient
            {
                Id = ingredientDTO.Id,
                Name = ingredientDTO.Name,
                CocktailIngredients = ingredientDTO.CocktailIngredients,
                Description = ingredientDTO.Name,
                Quantity = ingredientDTO.Quantity,
                Rating = ingredientDTO.Rating,
                IsDeleted = ingredientDTO.IsDeleted,
                IsAlcoholic = ingredientDTO.IsAlcoholic
            };
        }

        public static ICollection<Ingredient> GetEntities(this ICollection<IngredientDTO> ingredientDTOs)
        {
            return ingredientDTOs.Select(GetEntity).ToList();
        }
    }
}
