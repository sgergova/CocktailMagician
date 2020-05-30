using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers
{
    public static class BarCommentVmExtensions
    {
        public static BarCommentViewModel GetViewModel(this BarCommentDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new BarCommentViewModel
            {
                BarId = item.BarId,
                UserId=item.UserId,
                Comment = item.Comments,
               
         
            };
        }
        public static ICollection<BarCommentViewModel> GetViewModels(this ICollection<BarCommentDTO> items)
        {
            return items.Select(GetViewModel).ToList();
        }
        public static BarCommentDTO GetDtoFromVM(this BarCommentViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new BarCommentDTO
            {
                UserId = item.UserId,
                BarId = item.BarId,
                Comments = item.Comment,
               
            };
        }
        public static ICollection<BarCommentDTO> GetDtoFromVMs(this ICollection<BarCommentViewModel> items)
        {
            return items.Select(GetDtoFromVM).ToList();
        }

    }
}

