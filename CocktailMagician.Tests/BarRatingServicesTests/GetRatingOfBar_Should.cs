using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarRatingServicesTests
{
    [TestClass]
   public class GetRatingOfBar_Should
    {
      

        [TestMethod]
        public async Task GetRatingOfBar_Throws_When_RatingFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetRatingOfBar_Throws_When_RatingFound));

            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarRatingServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetRatingOfBar(bar.Id));
            }
        }
    }
}
//public async Task<BarRatingDTO> GetRatingOfBar(Guid barId)
//{
//    var barRating = await this.context.BarRatings
//                               .Include(b => b.Bar)
//                               .Include(b => b.User)
//                               .Where(br => br.BarId == barId)
//                               .FirstOrDefaultAsync()
//                               ?? throw new ArgumentNullException(Exceptions.NullEntityId);


//    return barRating.GetDTO();
//}