using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailRatingServicesTests
{
    [TestClass]
   public class GetRatingOfCocktail_Should
    {
        [TestMethod]
        public async Task GetRatingOfBar_Throws_When_RatingFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetRatingOfBar_Throws_When_RatingFound));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };

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

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetRatingOfCocktail(cocktail.Id));
            }
        }
    }
}
