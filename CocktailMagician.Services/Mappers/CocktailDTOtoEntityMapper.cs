using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public static class CocktailDTOtoEntityMapper
    {
        public static CocktailDTO Map(this Cocktail item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new CocktailDTO
            {
                Id = item.Id,
                AlcoholPercentage = item.AlcoholPercentage,
                Bars = item.Bars,
                Comments = item.Comments,
                ImageURL = item.ImageURL,
                Ingredients = item.Ingredients,
                IsAlcoholic = item.IsAlcoholic,
                Name = item.Name,
                Rating = item.Rating,
                Stars = item.Stars
            };
        }

        public static ICollection<CocktailDTO> Map(this ICollection<Cocktail> items)
        {
            return items.Select(Map).ToList();
        }
        public static Cocktail Map(this CocktailDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new Cocktail
            {
                Id = item.Id,
                AlcoholPercentage = item.AlcoholPercentage,
                Bars = item.Bars,
                Comments = item.Comments,
                ImageURL = item.ImageURL,
                Ingredients = item.Ingredients,
                IsAlcoholic = item.IsAlcoholic,
                Name = item.Name,
                Rating = item.Rating,
                Stars = item.Stars
            };
        }

        public static ICollection<Cocktail> Map(this ICollection<CocktailDTO> items)
        {
            return items.Select(Map).ToList();
        }
    }
}
