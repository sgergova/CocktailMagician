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

namespace CocktailMagician.Tests.BarCommentsServicesTests
{
    [TestClass]
    public class GetAllCommentsForBar_Should
    {
        [TestMethod]
        public async Task GetAllCommentsForBar_Returns_Correct_WhenParam_IsValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsForBar_Returns_Correct_WhenParam_IsValid));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var user2 = new User { Id = Guid.NewGuid(), UserName = "Petur" };

            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var barComment = new BarComment { BarId = bar.Id, UserId = user.Id };
            var barComment2 = new BarComment { BarId = bar.Id, UserId = user2.Id };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Users.AddRangeAsync(user, user2);
                await arrangeContext.BarComments.AddRangeAsync(barComment, barComment2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);
                var result = await sut.GetAllCommentsForBar(bar.Id, "Manhattan");

                Assert.AreEqual(2, result.Count());
                Assert.AreEqual(result.ToList()[0].UserId, user.Id);
                Assert.AreEqual(result.ToList()[1].UserId, user2.Id);
                Assert.IsInstanceOfType(result, typeof(ICollection<BarCommentDTO>));
            }
        }

        [TestMethod]
        public async Task GetAllCommentsForBar_Returns_OnlyExistingEntities()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsForBar_Returns_OnlyExistingEntities));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var user2 = new User { Id = Guid.NewGuid(), UserName = "Petur" };

            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var barComment = new BarComment { BarId = bar.Id, UserId = user.Id };
            var barComment2 = new BarComment { BarId = bar.Id, UserId = user2.Id, IsDeleted = true };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Users.AddRangeAsync(user, user2);
                await arrangeContext.BarComments.AddRangeAsync(barComment, barComment2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);
                var result = await sut.GetAllCommentsForBar(bar.Id, "Manhattan");

                Assert.AreEqual(1, result.Count());
            }
        }
        [TestMethod]
        public async Task GetAllCommentsForBar_Throws_When_NoCommentsFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsForBar_Throws_When_NoCommentsFound));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetAllCommentsForBar(bar.Id, "Manhattan"));
            }
        }

        [TestMethod]
        public async Task GetAllCommentsForBar_Throws_When_NoBarName_Passed()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsForBar_Throws_When_NoBarName_Passed));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetAllCommentsForBar(bar.Id, null));
            }
        }
    }
}
