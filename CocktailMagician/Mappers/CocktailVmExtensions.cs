using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers
{
    public static class CocktailVmExtensions
    {


        public static CocktailViewModel GetViewModel(this CocktailDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new CocktailViewModel
            {
                Id = item.Id,
                AlcoholPercentage = item.AlcoholPercentage,
                ImageURL = item.ImageURL,
                IsAlcoholic = item.IsAlcoholic,
                Name = item.Name,
                Rating = item.Rating,
                Bars = item.Bars.GetDTOs(),
                Comments = item.Comments.GetDTOs(),
                Ingredients = item.Ingredients.GetDTOs(),
                Stars = item.Stars,
            };
        }
        public static ICollection<CocktailViewModel> GetViewModels(this ICollection<CocktailDTO> items)
        {
            return items.Select(GetViewModel).ToList();
        }
        public static CocktailDTO GetDtoFromVM(this CocktailViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new CocktailDTO
            {

                Id = item.Id,
                AlcoholPercentage = item.AlcoholPercentage,
                ImageURL = item.ImageURL,
                IsAlcoholic = item.IsAlcoholic,
                Name = item.Name,
                Rating = item.Rating,
                Bars = item.Bars.GetEntities(),
                Comments = item.Comments.GetEntities(),
                Ingredients = item.Ingredients.GetEntities(),
                Stars = item.Stars,
            };
        }
        public static ICollection<CocktailDTO> GetDtoFromVMs(this ICollection<CocktailViewModel> items)
        {
            return items.Select(GetDtoFromVM).ToList();
        }

    }


}

