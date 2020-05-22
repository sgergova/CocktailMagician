using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services.CommonMessages;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<CocktailCommentsDTO> DeleteComment(Guid commentId)
        {
            var comment = await this.context.CocktailComments
                                            .FirstOrDefaultAsync(cc=>cc.IsDeleted == false && cc.CocktailId == commentId)
                                            ?? throw new ArgumentNullException(Exceptions.EntityNotFound);
            comment.IsDeleted = true;
            comment.DeletedOn = DateTime.UtcNow;

            this.context.CocktailComments.Update(comment);
            await this.context.SaveChangesAsync();

            return comment.GetDTO();
        }

        public async Task<ICollection<CocktailCommentsDTO>> GetAllCommentsOfUser(Guid? id, string username)
        {
            var comments = await this.context.CocktailComments
                                     .Where(cc => cc.IsDeleted == false && cc.UserId == id || cc.User.Name == username)
                                     .ToListAsync();

            return comments.GetDTOs();
        }
    }
}
