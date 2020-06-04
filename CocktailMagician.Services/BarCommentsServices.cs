using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;

using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services.CommonMessages;

namespace CocktailMagician.Services
{
    public class BarCommentsServices : IBarCommentsServices
    {
        private readonly CMContext context;

        public BarCommentsServices(CMContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// Provides all the comments that a current user has made.
        /// </summary>
        /// <param name="id">The ID of user</param>
        /// <returns>Sequence of comments</returns>
        public async Task<ICollection<BarCommentDTO>> GetAllCommentsOfUser(Guid id)
        {
            var comments = await this.context.BarComments
                                      .Include(bc=>bc.Bar)
                                      .Include(b=>b.User)
                                      .Where(bc=>bc. IsDeleted == false && bc.UserId == id )
                                      .ToListAsync();

            return comments.GetDTOs();
        }
        /// <summary>
        /// Provides all the comments for the current bar.
        /// </summary>
        /// <param name="barId">The ID of bar</param>
        /// <returns>Sequence of comments</returns>
        public async Task<ICollection<BarCommentDTO>> GetAllCommentsOfBar(Guid? barId)
        {
            var comments = await this.context.BarComments
                                      .Include(bc => bc.Bar)
                                      .Include(bc => bc.User)
                                      .Where(bc => bc.IsDeleted == false && bc.BarId == barId)
                                      .ToListAsync()
                                      ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return comments.GetDTOs();
        }
        /// <summary>
        /// Takes the ID of the user and as well of the bar and creates new comment. 
        /// </summary>
        /// <param name="barComment">The data tranfer object of bar comment that should be created</param>
        /// <returns>The created comment of bar</returns>
        public async Task<BarCommentDTO> CreateComment(BarCommentDTO barComment)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u=>u.Id == barComment.UserId)
                                               ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var bar = await this.context.Bars.FirstOrDefaultAsync(b=>b.Id == barComment.BarId)
                                               ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var newBarComment = barComment.GetEntity();

            this.context.Bars.Update(bar);
            this.context.Users.Update(user);
            await this.context.BarComments.AddAsync(newBarComment);
            await this.context.SaveChangesAsync();

            return newBarComment.GetDTO();
        }
        /// <summary>
        /// Finds the bar comment that should be deleted, searching by given ID, if it exists - marks the comment as deleted.
        /// </summary>
        /// <param name="barCommentId">The ID of bar comment that should be deleted</param>
        /// <returns>Data transfer object of deleted bar comment</returns>
        public async Task<BarCommentDTO> DeleteComment(Guid barCommentId)
        {
            var comment = await GetBarCommentsQuerable()
                                            .FirstOrDefaultAsync(bc=>bc.Id == barCommentId)
                                            ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            comment.IsDeleted = true;
            comment.DeletedOn = DateTime.UtcNow;
            this.context.BarComments.Update(comment);
            await this.context.SaveChangesAsync();

            return comment.GetDTO();
        }
        /// <summary>
        /// Finds the bar comment that should be edited, searching it by given ID and applies the changes made.
        /// </summary>
        /// <param name="barCommentId">The ID of bar comment that should be edited</param>
        /// <param name="updates">The changes that should be applied.</param>
        /// <returns>The modifed bar comment</returns>
        public async Task<BarCommentDTO> EditComment(Guid barCommentId, string updates)
        {
            var comment = await GetBarCommentsQuerable()
                                           .FirstOrDefaultAsync(bc => bc.Id == barCommentId)
                                            ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            comment.Comments = updates;
            comment.ModifiedOn = DateTime.UtcNow;

            this.context.BarComments.Update(comment);
            await this.context.SaveChangesAsync();

            return comment.GetDTO();
        }
        /// <summary>
        /// Takes the ID or the name of bar and finds all comments which are made and are not marked as deleted.
        /// </summary>
        /// <param name="id">The ID of the bar</param>
        /// <param name="barName">The name of the bar</param>
        /// <returns>Sequence of all made comments</returns>
        public async Task<ICollection<BarCommentDTO>> GetAllCommentsForBar(Guid? id, string barName)
        {
            var barComments = await GetBarCommentsQuerable()
                                            .Where(b=>b.BarId == id || b.Bar.Name == barName)
                                            .ToListAsync()
                                            ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return barComments.GetDTOs();
        }
      
        private IQueryable<BarComment> GetBarCommentsQuerable ()
        {
            var comments = this.context.BarComments
                                            .Include(bc => bc.User)
                                            .Where(bc => bc.IsDeleted == false)
                                            ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return comments;
        }
    }
}
