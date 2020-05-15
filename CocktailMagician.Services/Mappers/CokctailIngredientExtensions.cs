using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public static class CokctailIngredientExtensions
    {

        public static CocktailIngredientDTO GetDTO(this CocktailIngredient item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return new CocktailIngredientDTO
            {
                Cocktail = item.Cocktail,
                CocktailId = item.CocktailId,
                Ingredient = item.Ingredient,
                IngredientId = item.IngredientId
            };
        }


        public static ICollection<CocktailIngredientDTO> GetDTOs(this ICollection<CocktailIngredient> items)
        {
            return items.Select(GetDTO).ToList();
        }
        public static CocktailIngredient GetEntity(this CocktailIngredientDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return new CocktailIngredient
            {
                Cocktail = item.Cocktail,
                CocktailId = item.CocktailId,
                Ingredient = item.Ingredient,
                IngredientId = item.IngredientId
            };
        }

        public static ICollection<CocktailIngredient> GetEntities(this ICollection<CocktailIngredientDTO> items)
        {
            return items.Select(GetEntity).ToList();
        }
    }

}

