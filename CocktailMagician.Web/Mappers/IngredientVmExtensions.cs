using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers
{
    public static class IngredientVmExtensions
    {
        public static IngredientViewModel GetViewModel(this IngredientDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new IngredientViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Quantity = item.Quantity,
               
            };
        }
        public static ICollection<IngredientViewModel> GetViewModels(this ICollection<IngredientDTO> items)
        {
            return items.Select(GetViewModel).ToList();
        }
        public static IngredientDTO GetDtoFromVM(this IngredientViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new IngredientDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Quantity = item.Quantity,

            };
        }
        public static ICollection<IngredientDTO> GetDtoFromVMs(this ICollection<IngredientViewModel> items)
        {
            return items.Select(GetDtoFromVM).ToList();
        }

    }
}

