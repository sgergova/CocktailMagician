using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
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
    public class BarRatingServices : IBarRatingServices
    {
        private readonly CMContext context;

        public BarRatingServices(CMContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Creates a new instance of bar rating.
        /// </summary>
        /// <param name="rating">The rating that shoud be created</param>
        /// <returns>Data transfer object of the created instance of the rating</returns>
        public async Task<BarRatingDTO> CreateRating(BarRatingDTO rating)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.Id == rating.UserId)
                                               ?? throw new ArgumentNullException();

            var bar = await this.context.Bars.FirstOrDefaultAsync(c => c.Id == rating.BarId)
                                                ?? throw new ArgumentNullException();

            var newRating = rating.GetEntity();
            bar.RatedCount++;
            bar.RatingSum += rating.Rating;

            bar.AverageRating = bar.RatingSum / bar.RatedCount;
                 
            this.context.Users.Update(user);
            this.context.Bars.Update(bar);
            await this.context.AddAsync(newRating);
            await this.context.SaveChangesAsync();

            return newRating.GetDTO();
        }
        /// <summary>
        /// Gets all ratings left of given bar.
        /// </summary>
        /// <param name="barId">The ID of the bar</param>
        /// <returns>Sequence of the ratings</returns>
        public async Task<BarRatingDTO> GetRatingOfBar(Guid barId)
        {
            var barRating = await this.context.BarRatings
                                       .Include(b => b.Bar)
                                       .Include(b => b.User)
                                       .Where(br => br.BarId == barId)
                                       .FirstOrDefaultAsync();

            return barRating.GetDTO();
        }
    }
}
