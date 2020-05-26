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

namespace CocktailMagician.Services
{
    public class BarCommentsServices : IBarCommentsServices
    {
        private readonly CMContext context;

        public BarCommentsServices(CMContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<BarCommentDTO>> GetAllCommentsOfUser(Guid? id, string username)
        {
            var comments = await this.context.BarComments
                                      .Include(bc=>bc.Bar)
                                      .Where(bc=>bc. IsDeleted == false && bc.UserId == id || bc.User.UserName == username)
                                      .ToListAsync();

            return comments.GetDTOs();
        }
        public async Task<BarCommentDTO> CreateComment(BarCommentDTO barComment)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u=>u.Id == barComment.UserId)
                                               ?? throw new ArgumentNullException();

            var bar = await this.context.Bars.FirstOrDefaultAsync(b=>b.Id == barComment.BarId)
                                               ?? throw new ArgumentNullException();

            var newBarComment = barComment.GetEntity();

            this.context.Bars.Update(bar);
            this.context.Users.Update(user);
            await this.context.BarComments.AddAsync(newBarComment);
            await this.context.SaveChangesAsync();

            return newBarComment.GetDTO();
        }

        public async Task<BarCommentDTO> DeleteComment(Guid barCommentId)
        {
            var comment = await GetBarCommentsQuerable()
                                            .FirstOrDefaultAsync(bc=>bc.Id == barCommentId);

            comment.IsDeleted = true;
            comment.DeletedOn = DateTime.UtcNow;
            this.context.BarComments.Update(comment);
            await this.context.SaveChangesAsync();

            return comment.GetDTO();
        }

        public async Task<BarCommentDTO> EditComment(Guid barCommentId, string updates)
        {
            var comment = await GetBarCommentsQuerable()
                                           .FirstOrDefaultAsync(bc => bc.Id == barCommentId);

            comment.Comments = updates;
            comment.ModifiedOn = DateTime.UtcNow;

            this.context.BarComments.Update(comment);
            await this.context.SaveChangesAsync();

            return comment.GetDTO();
        }

        public async Task<ICollection<BarCommentDTO>> GetAllCommentsForBar(Guid? id, string barName)
        {
            var barComments = await GetBarCommentsQuerable()
                                            .Where(b=>b.BarId == id || b.Bar.Name == barName)
                                            .ToListAsync();

            return barComments.GetDTOs();
        }

        private IQueryable<BarComment> GetBarCommentsQuerable ()
        {
            var comments = this.context.BarComments
                                            .Include(bc => bc.User)
                                            .Where(bc => bc.IsDeleted == false)
                                            ?? throw new ArgumentNullException();

            return comments;
        }
    }
}
