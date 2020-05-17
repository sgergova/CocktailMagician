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
        public static BarDTO GetDTO(this Bar bar)
        {
            if (bar == null)
                throw new ArgumentNullException();
            
            var dto = new BarDTO
            {
                Id = bar.Id,
                Name = bar.Name,
                Address = bar.Address,
                Phone = bar.Phone, 
                Rating = bar.Rating,
                BarCocktails = bar.BarCocktails,
                Comments = bar.Comments,
                ImageURL = bar.BarImageURL,
                CountryId = bar.CountryId,
                CountryName = bar.Country.Name,
                IsDeleted = bar.IsDeleted
                
            };
            return dto;
        }

        public static ICollection<BarDTO> GetDTOs(this ICollection<Bar> bars)
        {
            return bars.Select(GetDTO).ToList();
        }

        public static Bar GetEntity(this BarDTO barDTO)
        {
            if (barDTO == null)
                throw new ArgumentNullException();

            var bar = new Bar
            {
                Id = barDTO.Id,
                Name = barDTO.Name,
                Address = barDTO.Address,
                Phone = barDTO.Phone,
                Rating = barDTO.Rating,
                BarCocktails = barDTO.BarCocktails,
                Comments = barDTO.Comments,
                BarImageURL = barDTO.ImageURL,
                CountryId = barDTO.CountryId,
                Country = barDTO.GetEntity().Country
            };

            return bar;
        }

        public static ICollection<Bar> GetEntities(this ICollection<BarDTO> barDTOs)
        {
            return barDTOs.Select(GetEntity).ToList();
        }
    }
}
