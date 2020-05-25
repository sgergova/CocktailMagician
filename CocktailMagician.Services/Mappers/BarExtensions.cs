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
                BarCocktails = bar.BarCocktails?.GetDTOs(),
                Comments = bar.Comments?.GetDTOs(),
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

        public static Bar GetEntity(this BarDTO bar)
        {
            if (bar == null)
                throw new ArgumentNullException();

            var newBar = new Bar
            {
                Id = bar.Id,
                Name = bar.Name,
                Address = bar.Address,
                Phone = bar.Phone,
                Rating = bar.Rating,
                BarCocktails = bar.BarCocktails?.GetEntities(),
                Comments = bar.Comments?.GetEntities(),
                BarImageURL = bar.ImageURL,
                CountryId = bar.CountryId,
                CreatedOn = bar.CreatedOn,
            };
            return newBar;
        }
         public static ICollection<Bar> GetEntities(this ICollection<BarDTO> bars)
        {
            return bars.Select(GetEntity).ToList();
        }
    }
}
