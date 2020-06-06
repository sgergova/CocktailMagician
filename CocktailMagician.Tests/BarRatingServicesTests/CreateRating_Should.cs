using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarRatingServicesTests
{
    [TestClass]
    public class CreateRating_Should
    {
        [TestMethod]
        public async Task CreateRating_CreatesCorrect_WhenParamsAre_Valid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateRating_CreatesCorrect_WhenParamsAre_Valid));

            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };

            var barRatingDTO = new BarRatingDTO { BarId = bar.Id, UserId = user.Id };

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
                var result = await sut.CreateRating(barRatingDTO);

                Assert.AreEqual(1, assertContext.BarRatings.Count());
                Assert.AreEqual("Manhattan",result.Bar.Name);
                Assert.AreEqual("Ivan", result.User.UserName);
            }
        }

        [TestMethod]
        public async Task CreateRating_Throws_WhenNoUserFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateRating_Throws_WhenNoUserFound));

            var bar = new Bar { Id = Guid.NewGuid(), Name= "Manhattan"};
            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var userId = Guid.NewGuid();

            var barRatingDTO = new BarRatingDTO { BarId = bar.Id, UserId = userId };

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

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateRating(barRatingDTO));
            }
        }

        [TestMethod]
        public async Task CreateRating_Throws_WhenNoBarFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateRating_Throws_WhenNoBarFound));

            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var barId = Guid.NewGuid();

            var barRatingDTO = new BarRatingDTO { BarId = barId, UserId = user.Id };

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

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateRating(barRatingDTO));
            }
        }
    }
}
//public async Task<BarRatingDTO> CreateRating(BarRatingDTO rating)
//{
//    var user = await this.context.Users.FirstOrDefaultAsync(u => u.Id == rating.UserId)
//                                         ?? throw new ArgumentNullException(Exceptions.NullEntityId);

//    var bar = await this.context.Bars.FirstOrDefaultAsync(c => c.Id == rating.BarId)
//                                        ?? throw new ArgumentNullException(Exceptions.NullEntityId);

//    var newRating = rating.GetEntity();

//    this.context.Users.Update(user);
//    this.context.Bars.Update(bar);
//    await this.context.AddAsync(newRating);
//    await this.context.SaveChangesAsync();

//    return newRating.GetDTO();
//}