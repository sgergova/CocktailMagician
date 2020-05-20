using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public static class BarCommentExtensions
    {
        public static BarCommentDTO GetDTO(this BarComment item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return new BarCommentDTO
            {
                BarId = item.BarId,
                Bar = item.Bar,
                IsDeleted = item.IsDeleted,
                Comments = item.Comments,
                CreatedOn = item.CreatedOn,
                DeletedOn = item.DeletedOn,
                ModifiedOn = item.ModifiedOn,
                User = item.User,
                UserId = item.UserId
            };
        }


        public static ICollection<BarCommentDTO> GetDTOs(this ICollection<BarComment> barComments)
        {
            return barComments.Select(GetDTO).ToList();
        }
    }
}
