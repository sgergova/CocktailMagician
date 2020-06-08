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

namespace CocktailMagician.Tests.CocktailCommentServicesTests
{
    [TestClass]
   public class CreateComment_Should
    {
        [TestMethod]
        public async Task CreateComment_Creates_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateComment_Creates_Correct));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };

            var cocktailCommentDTO = new CocktailCommentsDTO { CocktailId = cocktail.Id, UserId = user.Id, Comments="Great"};


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(user);
                await arrangeContext.Cocktails.AddRangeAsync(cocktail);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailCommentServices(assertContext);
                var result = await sut.CreateComment(cocktailCommentDTO);

                Assert.AreEqual(cocktail.Id, result.CocktailId);
                Assert.AreEqual(user.Id, result.UserId);
                Assert.AreEqual(1, assertContext.CocktailComments.Count());
                Assert.IsInstanceOfType(result, typeof(CocktailCommentsDTO));
            }

        }
        [TestMethod]
        public async Task CreateComment_Throws_When_NoCocktailFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateComment_Throws_When_NoCocktailFound));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var cocktailId = Guid.NewGuid();

            var cocktailCommentDTO = new CocktailCommentsDTO { CocktailId = cocktailId, UserId = user.Id };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailCommentServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateComment(cocktailCommentDTO));
            }

        }

        [TestMethod]
        public async Task CreateComment_Throws_When_NoUserFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateComment_Throws_When_NoUserFound));

            var cocktail = new Cocktail  { Id = Guid.NewGuid(), Name = "Manhattan" };
            var userId = Guid.NewGuid();
            var cocktailCommentDTO = new CocktailCommentsDTO { CocktailId = cocktail.Id, UserId = userId };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddRangeAsync(cocktail);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailCommentServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateComment(cocktailCommentDTO));
            }

        }

    }
}

