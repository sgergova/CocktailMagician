using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers
{
    public static class BarRatingVmExtensions
    {
        public static BarRatingViewModel GetViewModel(this BarRatingDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new BarRatingViewModel
            {
                BarId = item.BarId,
                UserId = item.UserId,
                Rating = item.Rating,


            };
        }
        public static ICollection<BarRatingViewModel> GetViewModels(this ICollection<BarRatingDTO> items)
        {
            return items.Select(GetViewModel).ToList();
        }
        public static BarRatingDTO GetDtoFromVM(this BarRatingViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new BarRatingDTO
            {
                UserId = item.UserId,
                BarId = item.BarId,
                Rating = item.Rating,

            };
        }
        public static ICollection<BarRatingDTO> GetDtoFromVMs(this ICollection<BarRatingViewModel> items)
        {
            return items.Select(GetDtoFromVM).ToList();
        }

    }
}

