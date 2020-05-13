using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public static class BarExtensions
    {
        public static BarDTO GetBarDTO(this Bar bar)
        {
            if (bar == null)
                throw new ArgumentNullException();
            
            return new BarDTO
            {
                Id = bar.Id,
                Name = bar.Name,
                City = bar.City,
                Country = bar.Country,
                Address = bar.Address,
                Phone = bar.Phone, 
                Rating = bar.Rating,
                Cocktails = bar.Cocktails,
                Comments = bar.Comments,
                ImageURL = bar.ImageURL,

            };
        }

        public static ICollection<BarDTO> GetBarDTOs(this ICollection<Bar> bars)
        {
            return bars.Select(GetBarDTO).ToList();
        }

        public static Bar GetBarEntity(this BarDTO barDTO)
        {
            if (barDTO == null)
                throw new ArgumentNullException();

            var bar = new Bar
            {
                Id = barDTO.Id,
                Name = barDTO.Name,
                City = barDTO.City,
                Country = barDTO.Country,
                Address = barDTO.Address,
                Phone = barDTO.Phone,
                Rating = barDTO.Rating,
                Cocktails = barDTO.Cocktails,
                Comments = barDTO.Comments,
                ImageURL = barDTO.ImageURL,
            };

            return bar;
        }

        public static ICollection<Bar> GetBarEntities(this ICollection<BarDTO> barDTOs)
        {
            return barDTOs.Select(GetBarEntity).ToList();
        }
    }
}
