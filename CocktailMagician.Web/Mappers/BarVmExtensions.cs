﻿using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers
{
    public static class BarVmExtensions
    {
        public static BarViewModel GetViewModel(this BarDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new BarViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address,
                Phone = item.Phone,
                Rating = item.Rating,
                RatedCount = item.RatedCount,
                RatingSum = item.RatingSum,
                ImageURL = item.ImageURL,
                BarCocktails = item.BarCocktails,
                Comments = item.Comments.GetViewModels(),
                CountryId = item.CountryId,
                CountryName = item.CountryName
            };
        }
        public static ICollection<BarViewModel> GetViewModels(this ICollection<BarDTO> items)
        {
            return items.Select(GetViewModel).ToList();
        }
        public static BarDTO GetDtoFromVM(this BarViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new BarDTO
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address,
                Phone = item.Phone,
                RatedCount = item.RatedCount,
                RatingSum = item.RatingSum,
                Rating = item.Rating,
                ImageURL = item.ImageURL,
                CountryId = item.CountryId,
                CountryName = item.CountryName
            };
        }
        public static ICollection<BarDTO> GetDtoFromVMs(this ICollection<BarViewModel> items)
        {
            return items.Select(GetDtoFromVM).ToList();
        }

    }
}
