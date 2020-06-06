using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarCommentsServicesTests
{
    [TestClass]
    public class DeleteComment_Should
    {
        [TestMethod]
        public async Task DeleteComment_ShouldDelete_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(DeleteComment_ShouldDelete_Correct));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var barComment = new BarComment { BarId = bar.Id, UserId = user.Id };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.BarComments.AddAsync(barComment);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);
                var result = await sut.DeleteComment(barComment.Id);

                Assert.AreEqual(true, result.IsDeleted);
                Assert.AreEqual(user.Id, result.UserId);
                Assert.AreEqual(bar.Id, result.BarId);
                Assert.IsInstanceOfType(result, typeof(BarCommentDTO));
            }
        }

        [TestMethod]
        public async Task DeleteComment_Throws_When_NoCommentFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(DeleteComment_Throws_When_NoCommentFound));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var barComment = new BarComment { BarId = bar.Id, UserId = user.Id };
            var commentId = Guid.NewGuid();

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.BarComments.AddAsync(barComment);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteComment(commentId));
            }
        }
    }
}

