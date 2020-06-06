using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailRatingServicesTests
{
    [TestClass]
   public class CreateRating_Should
    {
        [TestMethod]
        public async Task CreateRating_CreatesCorrect_WhenParamsAre_Valid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateRating_CreatesCorrect_WhenParamsAre_Valid));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };

            var cocktailRatingDTO = new CocktailRatingDTO { CocktailId = cocktail.Id, UserId = user.Id };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CoktailRatingServices(assertContext);
                var result = await sut.CreateRating(cocktailRatingDTO);

                Assert.AreEqual(1, assertContext.CocktailRatings.Count());
                Assert.AreEqual("Manhattan", result.Cocktail.Name);
                Assert.AreEqual("Ivan", result.User.UserName);
            }
        }

       [TestMethod]
       public async Task CreateRating_Throws_WhenNoUserFound()
       {
           //Arrange
           var options = Utils.GetOptions(nameof(CreateRating_Throws_WhenNoUserFound));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var userId = Guid.NewGuid();

           var cocktailRatingDTO = new CocktailRatingDTO { CocktailId = cocktail.Id, UserId = userId };

           using (var arrangeContext = new CMContext(options))
           {
               await arrangeContext.Users.AddAsync(user);
               await arrangeContext.Cocktails.AddAsync(cocktail);
               await arrangeContext.SaveChangesAsync();
           }
           //Act, Assert
           using (var assertContext = new CMContext(options))
           {
               var sut = new CoktailRatingServices(assertContext);

               await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateRating(cocktailRatingDTO));
           }
       }

        [TestMethod]
        public async Task CreateRating_Throws_WhenNoBarFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateRating_Throws_WhenNoBarFound));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var cocktailId = Guid.NewGuid();

            var cocktailRatingDTO = new CocktailRatingDTO { CocktailId = cocktailId, UserId = user.Id };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CoktailRatingServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateRating(cocktailRatingDTO));
            }
        }
    }
}
