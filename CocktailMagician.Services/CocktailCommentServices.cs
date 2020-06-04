using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
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
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CocktailCommentsDTO> CreateComment(CocktailCommentsDTO comment)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u=>u.Id == comment.UserId)
                                                ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var cocktail = await this.context.Cocktails.FirstOrDefaultAsync(c=>c.Id == comment.CocktailId)
                                                ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var newCocktailComment = comment.GetEntity();

            this.context.Users.Update(user);
            this.context.Cocktails.Update(cocktail);
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
                                     .Where(cc => cc.IsDeleted == false && cc.UserId == id || cc.User.UserName == username)
                                     .ToListAsync()
                                      ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return comments.GetDTOs();
        }

        public async Task<ICollection<CocktailCommentsDTO>> GetAllCommentsForCocktail(Guid? id)
        {
            var comments = await this.context.CocktailComments
                                     .Where(cc => cc.IsDeleted == false && cc.CocktailId == id)
                                     .Include(cc => cc.User)
                                     .ToListAsync()
                                      ?? throw new ArgumentNullException(Exceptions.EntityNotFound); ;

            return comments.GetDTOs();
        }
    }
}
