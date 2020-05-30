using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers
{
    public static class CocktailRatingVmExtensions
    {
        public static CocktailRatingViewModel GetViewModel(this CocktailRatingDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new CocktailRatingViewModel
            {
                CocktailId = item.CocktailId,
                UserId = item.UserId,
                Rating = item.Rating,


            };
        }
        public static ICollection<CocktailRatingViewModel> GetViewModels(this ICollection<CocktailRatingDTO> items)
        {
            return items.Select(GetViewModel).ToList();
        }
        public static CocktailRatingDTO GetDtoFromVM(this CocktailRatingViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new CocktailRatingDTO
            {
                UserId = item.UserId,
                CocktailId = item.CocktailId,
                Rating = item.Rating,

            };
        }
        public static ICollection<CocktailRatingDTO> GetDtoFromVMs(this ICollection<CocktailRatingViewModel> items)
        {
            return items.Select(GetDtoFromVM).ToList();
        }

    }
}

