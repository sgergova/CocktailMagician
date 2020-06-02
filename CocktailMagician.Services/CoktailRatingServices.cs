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
        /// <summary>
        /// Creates a new instance of cocktail rating.
        /// </summary>
        /// <param name="rating">The rating that shoud be created</param>
        /// <returns>Data transfer object of the created instance of the rating</returns>
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
        /// <summary>
        /// Gets all ratings left of given cocktail.
        /// </summary>
        /// <param name="cocktailId">The ID of the cocktail</param>
        /// <returns>Sequence of the ratings</returns>
        public async Task<CocktailRatingDTO> GetRatingOfCocktail(Guid cocktailId)
        {
            var cocktailRating = await this.context.CocktailRatings
                                                   .Include(c => c.Cocktail)
                                                   .Include(c => c.User)
                                                   .Where(c => c.CocktailId == cocktailId)
                                                   .FirstOrDefaultAsync();

            return cocktailRating.GetDTO();
        }
    }
}
