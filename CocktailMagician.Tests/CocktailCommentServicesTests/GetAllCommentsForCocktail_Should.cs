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
   public class GetAllCommentsForCocktail_Should
    {
        [TestMethod]
        public async Task GetAllCommentsForCocktail_Returns_Correct_WhenParam_IsValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsForCocktail_Returns_Correct_WhenParam_IsValid));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var user2 = new User { Id = Guid.NewGuid(), UserName = "Petur" };

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var cocktailComment = new CocktailComment { CocktailId = cocktail.Id, UserId = user.Id };
            var cocktailComment2 = new CocktailComment{ CocktailId = cocktail.Id, UserId = user2.Id };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.Users.AddRangeAsync(user, user2);
                await arrangeContext.CocktailComments.AddRangeAsync(cocktailComment, cocktailComment2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailCommentServices(assertContext);
                var result = await sut.GetAllCommentsForCocktail(cocktail.Id);

                Assert.AreEqual(2, result.Count());
                Assert.AreEqual(result.ToList()[0].UserId, user.Id);
                Assert.AreEqual(result.ToList()[1].UserId, user2.Id);
                Assert.IsInstanceOfType(result, typeof(ICollection<CocktailCommentsDTO>));
            }
        }

        [TestMethod]
        public async Task GetAllCommentsForCocktail_Returns_OnlyExistingEntities()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsForCocktail_Returns_OnlyExistingEntities));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var user2 = new User { Id = Guid.NewGuid(), UserName = "Petur" };

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var cocktailComment = new CocktailComment { CocktailId = cocktail.Id, UserId = user.Id };
            var cocktailComment2 = new CocktailComment { CocktailId = cocktail.Id, UserId = user2.Id, IsDeleted = true };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.Users.AddRangeAsync(user, user2);
                await arrangeContext.CocktailComments.AddRangeAsync(cocktailComment, cocktailComment2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailCommentServices(assertContext);
                var result = await sut.GetAllCommentsForCocktail(cocktail.Id);

                Assert.AreEqual(1, result.Count());
            }
        }
        [TestMethod]
        public async Task GetAllCommentsForCocktail_Throws_When_NoCommentsFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsForCocktail_Throws_When_NoCommentsFound));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailCommentServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetAllCommentsForCocktail(cocktail.Id));
            }
        }
    }
}
