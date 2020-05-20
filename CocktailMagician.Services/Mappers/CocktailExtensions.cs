using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public static class CocktailExtensions
    {
        public static CocktailDTO GetDTO(this Cocktail item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return new CocktailDTO
            {
                Id = item.Id,
                AlcoholPercentage = item.AlcoholPercentage,
                Bars = item.Bars.GetDTOs(),
                Comments = item.Comments,
                ImageURL = item.ImageURL,
                Ingredients = item.CocktailIngredients.GetDTOs(),
                IsAlcoholic = item.IsAlcoholic,
                Name = item.Name,
                Rating = item.Rating,
                IsDeleted = item.IsDeleted,
                DeletedOn = item.DeletedOn,
                ModifiedOn = item.ModifiedOn
            };
        }

        public static ICollection<CocktailDTO> GetDTOs(this ICollection<Cocktail> items)
        {
            return items.Select(GetDTO).ToList();
        }
    }
}
