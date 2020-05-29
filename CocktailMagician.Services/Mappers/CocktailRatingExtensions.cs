using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
   public static class CocktailRatingExtensions
    {
        public static CocktailRatingDTO GetDTO(this CocktailRating rating)
        {
            if (rating == null)
                throw new ArgumentNullException();

            return new CocktailRatingDTO
            {
                Cocktail = rating.Cocktail,
                CocktailId = rating.CocktailId,
                User = rating.User,
                UserId = rating.UserId,
                Vote = rating.Vote,
            };
        }
        public static ICollection<CocktailRatingDTO> GetDTOs(this ICollection<CocktailRating> ratings)
        {
            return ratings.Select(GetDTO).ToList();
        }

        public static CocktailRating GetEntity(this CocktailRatingDTO rating)
        {
            if (rating == null)
                throw new ArgumentNullException();

            return new CocktailRating
            {
                Cocktail = rating.Cocktail,
                CocktailId = rating.CocktailId,
                User = rating.User,
                UserId = rating.UserId,
                Vote = rating.Vote,
            };
        }

        public static ICollection<CocktailRating> GetEntities(this ICollection<CocktailRatingDTO> ratings)
        {
            return ratings.Select(GetEntity).ToList();
        }
    }
}

