using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public static class BarRatingExtensions
    {
        public static BarRatingDTO GetDTO(this BarRating rating)
        {
            if (rating == null)
                throw new ArgumentNullException();

            return new BarRatingDTO
            {
                Bar = rating.Bar,
                BarId = rating.BarId,
                User = rating.User,
                UserId = rating.UserId,
                Rating = rating.Rating,
            };
        }
        public static ICollection<BarRatingDTO> GetDTOs(this ICollection<BarRating> ratings)
        {
            return ratings.Select(GetDTO).ToList();
        }

        public static BarRating GetEntity(this BarRatingDTO rating)
        {
            if (rating == null)
                throw new ArgumentNullException();

            return new BarRating
            {
                Bar = rating.Bar,
                BarId = rating.BarId,
                User = rating.User,
                UserId = rating.UserId,
                Rating = rating.Rating,
            };
        }


        public static ICollection<BarRating> GetEntities(this ICollection<BarRatingDTO> ratings)
        {
            return ratings.Select(GetEntity).ToList();
        }
    }
}
