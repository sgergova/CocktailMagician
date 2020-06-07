using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarServicesTests
{
    [TestClass]
    public class AddCocktailToBar_Should
    {
        [TestMethod]
        public async Task AddCocktailToBar_Throws_WhenBarId_IsInvalid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddCocktailToBar_Throws_WhenBarId_IsInvalid));

            var cocktailID = Guid.NewGuid();
            var barID = Guid.NewGuid();

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.AddCocktailToBar(barID, cocktailID));
            }

        }
        [TestMethod]
        public async Task AddCocktailToBar_Throws_When_BarCocktail_IsNotNull()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddCocktailToBar_Throws_When_BarCocktail_IsNotNull));

            var barID = Guid.NewGuid();
            var cocktailId = Guid.NewGuid();


            var barCocktail = new BarCocktail
            {
                BarId = barID,
                CocktailId = cocktailId
            };

            var cocktailDTO = new CocktailDTO
            {
                Id = cocktailId,
                Name = "Manhattan"
            };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.BarCocktails.AddAsync(barCocktail);
                await arrangeContext.SaveChangesAsync();
            }

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.AddCocktailToBar(barID, cocktailDTO.Id));
            }

        }

        [TestMethod]
        public async Task AddCocktailToBar_Adds_Correctly_When_Params_Are_Valid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddCocktailToBar_Adds_Correctly_When_Params_Are_Valid));


            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Cosmos",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Bulgaria"
                }
            };

            var cocktail = new Cocktail
            {
                Id = Guid.NewGuid(),
                Name = "Manhattan",
            };

            var cocktailDTO = new CocktailDTO
            {
                Id = cocktail.Id,
                Name = cocktail.Name,

            };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.SaveChangesAsync();
            }


            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = await sut.AddCocktailToBar(bar.Id, cocktailDTO.Id);

                Assert.AreEqual(1, assertContext.BarCocktails.Count());
                Assert.AreEqual(1, result.BarCocktails.Count());
                Assert.AreEqual(true, result.BarCocktails.ToList()[0].IsListed);
                Assert.IsInstanceOfType(result, typeof(BarDTO));
            }
        }

        [TestMethod]
        public async Task AddCocktailToBar_Throws_When_Cocktail_IsAreadyListed()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddCocktailToBar_Throws_When_Cocktail_IsAreadyListed));


            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Cosmos",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Bulgaria"
                }
            };

            var cocktail = new Cocktail
            {
                Id =Guid.NewGuid(),
                Name = "Manhattan",
            };

            var cocktailDTO = new CocktailDTO
            {
                Id = cocktail.Id,
                Name = cocktail.Name,

            };

            var barCocktail = new BarCocktail
            {
                BarId = bar.Id,
                CocktailId = cocktail.Id,
            };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.BarCocktails.AddAsync(barCocktail);
                await arrangeContext.SaveChangesAsync();
            }


            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => sut.AddCocktailToBar(bar.Id, cocktailDTO.Id));
            }
        }
    }

}


