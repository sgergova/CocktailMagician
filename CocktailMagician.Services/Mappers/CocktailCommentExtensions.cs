using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public static class CocktailCommentExtensions
    {
        public static CocktailCommentsDTO GetDTO(this CocktailComment item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return new CocktailCommentsDTO
            {
                Comments = item.Comments,
                User = item.User,
                UserId = item.UserId,
                Cocktail = item.Cocktail,
                CocktailId = item.CocktailId,
            };
        }


        public static ICollection<CocktailCommentsDTO> GetDTOs(this ICollection<CocktailComment> cocktailComments)
        {
            return cocktailComments.Select(GetDTO).ToList();
        }
        public static CocktailComment GetEntity(this CocktailCommentsDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return new CocktailComment
            {
                Comments = item.Comments,
                User = item.User,
                UserId = item.UserId,
                Cocktail = item.Cocktail,
                CocktailId = item.CocktailId,
            };
        }

        public static ICollection<CocktailComment> GetEntities(this ICollection<CocktailCommentsDTO> barCommentsDTOs)
        {
            return barCommentsDTOs.Select(GetEntity).ToList();
        }
    }
}

