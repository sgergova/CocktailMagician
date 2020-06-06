using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarCommentsServicesTests
{
    [TestClass]
   public class EditComment_Should
    {
        [TestMethod]
        public async Task EditComment_Updates_Correctly()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(EditComment_Updates_Correctly));

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
                var result = await sut.EditComment(barComment.Id, "Changes made");

                Assert.AreEqual("Changes made", result.Comments);
                Assert.IsInstanceOfType(result, typeof(BarCommentDTO));
            }
        }
        [TestMethod]
        public async Task EditComment_Throws_When_ContentIsNull()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(EditComment_Throws_When_ContentIsNull));

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

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.EditComment(commentId, null));
            }
        }

        [TestMethod]
        public async Task EditComment_Throws_When_NoCommentFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(EditComment_Throws_When_NoCommentFound));

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

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.EditComment(commentId, "Changes made"));
            }
        }
    }
}
