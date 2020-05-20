using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailsServicesTests
{
    [TestClass]
    public class GetCocktail_Should
    {
        [TestMethod]
        public async Task GetCocktail_Returns_Correct_WhenParamsIsValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetCocktail_Returns_Correct_WhenParamsIsValid));

            var cocktail = new Cocktail
            {
                Id = Guid.NewGuid(),
                Name = "Cuba Libre"
            };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result = await sut.GetCocktail(cocktail.Id);

                Assert.AreEqual(cocktail.Name, result.Name);
                Assert.IsInstanceOfType(result, typeof(CocktailDTO));
            }
        }

        [TestMethod]
        public async Task GetCocktail_Throws_When_CocktaiNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetCocktail_Throws_When_CocktaiNotFound));

            var cocktail = new Cocktail
            {
                Id = Guid.NewGuid(),
                Name = "Cuba Libre",
                IsDeleted = true,
            };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetCocktail(cocktail.Id));
            }
        }
    }
}
