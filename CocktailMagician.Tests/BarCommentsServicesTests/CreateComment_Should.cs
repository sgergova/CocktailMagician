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
   public class CreateComment_Should
    {
        [TestMethod]
        public async Task CreateComment_CreatesBar_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateComment_CreatesBar_Correct));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };

            var barCommentDTO = new BarCommentDTO { BarId = bar.Id, UserId = user.Id };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(user);
                await arrangeContext.Bars.AddRangeAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);
                var result = await sut.CreateComment(barCommentDTO);

                Assert.AreEqual(bar.Id, result.BarId);
                Assert.AreEqual(user.Id, result.UserId);
                Assert.AreEqual(1, assertContext.BarComments.Count());
                Assert.IsInstanceOfType(result, typeof(BarCommentDTO));
            }

        }
        [TestMethod]
        public async Task CreateComment_Throws_When_NoBarFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateComment_Throws_When_NoBarFound));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var barId = Guid.NewGuid();

            var barCommentDTO = new BarCommentDTO { BarId = barId, UserId = user.Id };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateComment(barCommentDTO));
            }

        }

        [TestMethod]
        public async Task CreateComment_Throws_When_NoUserFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateComment_Throws_When_NoUserFound));

            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var userId = Guid.NewGuid();
            var barCommentDTO = new BarCommentDTO { BarId = bar.Id, UserId = userId };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddRangeAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateComment(barCommentDTO));
            }

        }
    }
}
