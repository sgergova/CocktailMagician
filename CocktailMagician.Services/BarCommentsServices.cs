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
    public class BarCommentsServices : IBarCommentsServices
    {
        private readonly CMContext context;

        public BarCommentsServices(CMContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<BarCommentDTO>> GetAllCommentsOfUser(Guid? id, string username)
        {
            var comments = await this.context.BarComments
                                      .Where(bc=>bc. IsDeleted == false && bc.UserId == id || bc.User.Name == username)
                                      .ToListAsync();

            return comments.GetDTOs();
        }
        public async Task<BarCommentDTO> CreateComment(BarCommentDTO barComment)
        {
            var newBarComment = barComment.GetEntity();
            
            await this.context.BarComments.AddAsync(newBarComment);
            await this.context.SaveChangesAsync();

            return newBarComment.GetDTO();
        }

        public async Task<BarCommentDTO> DeleteComment(Guid barCommentId)
        {
            var comment = await this.context.BarComments
                                            .Include(bc => bc.User)
                                            .FirstOrDefaultAsync(bc => bc.IsDeleted == false && bc.Id == barCommentId)
                                            ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            comment.IsDeleted = true;
            comment.DeletedOn = DateTime.UtcNow;
            this.context.BarComments.Update(comment);
            await this.context.SaveChangesAsync();

            return comment.GetDTO();
        }

       
    }
}
