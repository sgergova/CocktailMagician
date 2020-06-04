using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
   public interface IBarCommentsServices
    {
        Task<ICollection<BarCommentDTO>> GetAllCommentsOfUser(Guid userId);
        Task<BarCommentDTO> CreateComment(BarCommentDTO barComment);
        Task<BarCommentDTO> DeleteComment(Guid barCommentId);
        Task<ICollection<BarCommentDTO>> GetAllCommentsOfBar(Guid barId);
    }
}
