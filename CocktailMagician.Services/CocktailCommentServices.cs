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
        /// <summary>
        /// Takes the ID of the user and as well of the cocktail and creates new comment. 
        /// </summary>
        /// <param name="comment">The data tranfer object of cocktail comment that should be created</param>
        /// <returns>The created comment as data tranfer object</returns>
        public async Task<CocktailCommentsDTO> CreateComment(CocktailCommentsDTO comment)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u=>u.Id == comment.UserId)
                                                ?? throw new ArgumentNullException();

            var cocktail = await this.context.Cocktails.FirstOrDefaultAsync(c=>c.Id == comment.CocktailId)
                                                ?? throw new ArgumentNullException();

            var newCocktailComment = comment.GetEntity();

            this.context.Users.Update(user);
            this.context.Cocktails.Update(cocktail);
            await this.context.CocktailComments.AddAsync(newCocktailComment);
            await this.context.SaveChangesAsync();

            return newCocktailComment.GetDTO();
        }
        /// <summary>
        /// Finds the comment that should be deleted, searching by given ID, if it exists - marks the comment as deleted.
        /// </summary>
        /// <param name="CommentId">The ID of comment that should be deleted</param>
        /// <returns>Data transfer object of deleted comment</returns>
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
        /// <summary>
        /// Provides all the comments for that a current user has made.
        /// </summary>
        /// <param name="id">The ID of user</param>
        /// <param name="barId">The ID of user</param>
        /// <returns>Sequence of comments</returns>
        public async Task<ICollection<CocktailCommentsDTO>> GetAllCommentsOfUser(Guid? id, string username)
        {
            var comments = await this.context.CocktailComments
                                     .Where(cc => cc.IsDeleted == false && cc.UserId == id || cc.User.UserName == username)
                                     .ToListAsync();

            return comments.GetDTOs();
        }
        /// <summary>
        /// Provides all the comments for the current cocktail.
        /// </summary>
        /// <param name="Id">The ID of cocktail</param>
        /// <param name="cocktailName">The name of cocktail</param>
        /// <returns>Sequence of comments</returns>
        public async Task<ICollection<CocktailCommentsDTO>> GetAllCommentsForCocktail(Guid? id, string cocktailName)
        {
            var comments = await this.context.CocktailComments
                                     .Where(cc => cc.IsDeleted == false && cc.CocktailId == id || cc.Cocktail.Name == cocktailName)
                                     .ToListAsync();

            return comments.GetDTOs();
        }
    }
}
