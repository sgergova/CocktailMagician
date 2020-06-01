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
                UserId = item.UserId,
                User = item.User,
                IsDeleted = item.IsDeleted,
                Comments = item.Comments,
                CreatedOn = item.CreatedOn,
                DeletedOn = item.DeletedOn,
                ModifiedOn = item.ModifiedOn,
            };
        }


        public static ICollection<BarCommentDTO> GetDTOs(this ICollection<BarComment> barComments)
        {
            return barComments.Select(GetDTO).ToList();
        }

        public static BarComment GetEntity(this BarCommentDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return new BarComment
            {
                BarId = item.BarId,
                UserId = item.UserId,
                Comments = item.Comments,
                CreatedOn = item.CreatedOn,
            };
        }
        public static ICollection<BarComment> GetEntities(this ICollection<BarCommentDTO> barComments)
        {
            return barComments.Select(GetEntity).ToList();
        }
    }
}
