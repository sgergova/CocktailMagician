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
                Bars = item.Bars?.GetDTOs(),
                Comments = item.Comments?.GetDTOs(),
                ImageURL = item.ImageURL,
                Ingredients = item.CocktailIngredients?.GetDTOs(),
                IsAlcoholic = item.IsAlcoholic,
                Name = item.Name,
                RatedCount = item.RatedCount,
                RatingSum = item.RatingSum,
                AverageRating = item.AverageRating,
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

        public static Cocktail GetEntity(this CocktailDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return new Cocktail
            {
                Id = item.Id,
                AlcoholPercentage = item.AlcoholPercentage,
                Bars = item.Bars?.GetEntities(),
                Comments = item.Comments?.GetEntities(),
                ImageURL = item.ImageURL,
                CocktailIngredients = item.Ingredients?.GetEntities(),
                IsAlcoholic = item.IsAlcoholic,
                Name = item.Name,
                RatedCount = item.RatedCount,
                RatingSum = item.RatingSum,
                AverageRating = item.AverageRating,
                Rating = item.Rating,
                CreatedOn = DateTime.UtcNow
            };
        }

        public static ICollection<Cocktail> GetEntities(this ICollection<CocktailDTO> items)
        {
            return items.Select(GetEntity).ToList();
        }
    }

}
