using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface ICocktailCommentServices
    {
        Task<ICollection<CocktailCommentsDTO>> GetAllCommentsOfUser(Guid? id, string username);
        Task<CocktailCommentsDTO> CreateComment(CocktailCommentsDTO comment);
        Task<CocktailCommentsDTO> DeleteComment(Guid commentId);
    }
}
