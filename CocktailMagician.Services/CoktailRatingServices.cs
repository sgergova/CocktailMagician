using CocktailMagician.Data.AppContext;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class CoktailRatingServices :ICocktailRatingServices
    {
        private readonly CMContext context;

        public CoktailRatingServices(CMContext context)
        {
            this.context = context;
        }

        public async Task<CocktailRatingDTO> CreateRating(CocktailRatingDTO rating)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u=>u.Id == rating.UserId)
                                                ?? throw new ArgumentNullException(); 
            
            var cocktatil = await this.context.Cocktails.FirstOrDefaultAsync(c=>c.Id == rating.Id)
                                                ?? throw new ArgumentNullException();

            var newRating = rating.GetEntity();

            this.context.Users.Update(user);
            this.context.Cocktails.Update(cocktatil);
            await this.context.CocktailRatings.AddAsync(newRating);
            await this.context.SaveChangesAsync();

            return newRating.GetDTO();
        }

        public async Task<CocktailRatingDTO> GetRatingOfBar(Guid userId, Guid cocktailId)
        {
            var cocktailRating = await this.context.CocktailRatings
                                                   .Include(c => c.Cocktail)
                                                   .Include(c => c.User)
                                                   .Where(c => c.CocktailId == cocktailId && c.UserId == userId)
                                                   .FirstOrDefaultAsync();

            return cocktailRating.GetDTO();
        }
    }
}
