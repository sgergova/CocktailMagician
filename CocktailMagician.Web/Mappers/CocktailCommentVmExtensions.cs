using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers
{
    public static class CocktailCommentVmExtensions
    {
        public static CocktailCommentViewModel GetViewModel(this CocktailCommentsDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return new CocktailCommentViewModel
            {
                CocktailId = item.CocktailId,
                UserId = item.UserId,
                Comment = item.Comments,


            };
        }
        public static ICollection<CocktailCommentViewModel> GetViewModels(this ICollection<CocktailCommentsDTO> items)
        {
            return items.Select(GetViewModel).ToList();
        }
        public static CocktailCommentsDTO GetDtoFromVM(this CocktailCommentViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new CocktailCommentsDTO
            {
                UserId = item.UserId,
                CocktailId = item.CocktailId,
                Comments = item.Comment,

            };
        }
        public static ICollection<CocktailCommentsDTO> GetDtoFromVMs(this ICollection<CocktailCommentViewModel> items)
        {
            return items.Select(GetDtoFromVM).ToList();
        }

    }
}
