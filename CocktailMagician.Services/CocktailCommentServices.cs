using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class CocktailCommentServices : ICocktailCommentServices
    {
        private readonly CMContext context;

        public CocktailCommentServices(CMContext context)
        {
            this.context = context;
        }
        public async Task<CocktailCommentsDTO> CreateComment(CocktailCommentsDTO comment)
        {
            var newCocktailComment = comment.GetEntity();

            await this.context.CocktailComments.AddAsync(newCocktailComment);
            await this.context.SaveChangesAsync();

            return newCocktailComment.GetDTO();

        }

        public Task<CocktailCommentsDTO> DeleteComment(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CocktailCommentsDTO>> GetAllCommentsOfUser(Guid? id, string username)
        {
            throw new NotImplementedException();
        }
    }
}
