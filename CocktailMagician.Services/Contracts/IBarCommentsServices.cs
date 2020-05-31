using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
   public interface IBarCommentsServices
    {
        Task<ICollection<BarCommentDTO>> GetAllCommentsOfUser(Guid? id, Guid? barId);
        Task<BarCommentDTO> CreateComment(BarCommentDTO barComment);
        Task<BarCommentDTO> DeleteComment(Guid barCommentId);
    }
}
