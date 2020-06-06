using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailCommentServicesTests
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
            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var cocktailComment = new CocktailComment { CocktailId = cocktail.Id, UserId = user.Id };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.CocktailComments.AddAsync(cocktailComment);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailCommentServices(assertContext);
                var result = await sut.DeleteComment(cocktailComment.Id);

                Assert.AreEqual(true, result.IsDeleted);
                Assert.IsInstanceOfType(result, typeof(CocktailCommentsDTO));
            }
        }

        [TestMethod]
        public async Task DeleteComment_Throws_When_NoCommentFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(DeleteComment_Throws_When_NoCommentFound));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var cocktailComment = new CocktailComment { CocktailId = cocktail.Id, UserId = user.Id };
            var commentId = Guid.NewGuid();

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.CocktailComments.AddAsync(cocktailComment);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailCommentServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteComment(commentId));
            }
        }
    }
}
