using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
   public interface ICocktailRatingServices
    {
        Task<CocktailRatingDTO> CreateRating(CocktailRatingDTO rating);
        Task<CocktailRatingDTO> GetRatingOfBar(Guid userId, Guid barId);
    }
}
