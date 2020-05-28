using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface IBarRatingServices
    {
        Task<BarRatingDTO> CreateRating(BarRatingDTO rating);
        Task<BarRatingDTO> GetRatingOfBar(Guid userId, Guid barId);
    }
}
