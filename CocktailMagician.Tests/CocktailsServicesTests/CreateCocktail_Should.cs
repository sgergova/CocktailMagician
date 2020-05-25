using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailsServicesTests
{
    [TestClass]
    public class CreateCocktail_Should
    {
        [TestMethod]
        public async Task CreateBar_Adds_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateBar_Adds_Correct));


            var cocktail = new CocktailDTO
            {
                Name = "Cuba Libre",
            };


            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result = await sut.CreateCocktail(cocktail);

                Assert.AreEqual(1, assertContext.Cocktails.Count());
            }
        }

        [TestMethod]
        public async Task CreateBar_Returns_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateBar_Returns_Correct));


            var cocktail = new CocktailDTO
            {
                Name = "Cuba Libre",
                IsAlcoholic = true
            };


            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result = await sut.CreateCocktail(cocktail);

                Assert.AreEqual(cocktail.Name, result.Name);
                Assert.AreEqual(true, result.IsAlcoholic);
                Assert.IsInstanceOfType(result, typeof(CocktailDTO));
            }
        }

        [TestMethod]
        public async Task CreateBar_Throws_When_NameExists()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateBar_Throws_When_NameExists));

            var cocktail = new Cocktail
            {
                Id = Guid.NewGuid(),
                Name = "Cuba Libre"
            };

            var cocktailDTO = new CocktailDTO
            {
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

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateCocktail(cocktailDTO));
            }
        }

        [TestMethod]
        public async Task CreateBar_Throws_When_NameIsNull()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateBar_Throws_When_NameIsNull));


            var cocktailDTO = new CocktailDTO
            {
                Name = null
            };


            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateCocktail(cocktailDTO));
            }
        }
    }
}

