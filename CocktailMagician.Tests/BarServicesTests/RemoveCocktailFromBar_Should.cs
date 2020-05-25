using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarServicesTests
{
    [TestClass]
    public class RemoveCocktailFromBar_Should
    {
        //TODO
        [TestMethod]
        public async Task RemoveCocktailFromBar_Throws_When_BarNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(RemoveCocktailFromBar_Throws_When_BarNotFound));

            var barId = Guid.Parse("ab80e784-3e0e-40b9-8e86-01fcf3f59cdd");
            var cocktailId = Guid.Parse("4581a55e-1e15-494f-b01d-701b734e142a");
            

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.RemoveCocktailFromBar(barId, cocktailId));
            }
        }

        [TestMethod]
        public async Task RemoveCocktailFromBar_Throws_When_CocktailNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(RemoveCocktailFromBar_Throws_When_CocktailNotFound));

            var barId = Guid.Parse("e77a6ff0-db47-4b52-ae26-e17c8c0fee4a");
            var cocktailId = Guid.Parse("2978a1eb-1fe1-47d6-864c-7234510907e7");


            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.RemoveCocktailFromBar(barId, cocktailId));
            }
        }

        [TestMethod]
        public async Task RemoveCocktailFromBar_Throws_When_CocktailId_IsNotCorrect()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(RemoveCocktailFromBar_Throws_When_CocktailId_IsNotCorrect));

            var barId = Guid.Parse("e77a6ff0-db47-4b52-ae26-e17c8c0fee4a");
            var cocktailId = Guid.Parse("2978a1eb-1fe1-47d6-864c-7234510907e7");


            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.RemoveCocktailFromBar(barId, cocktailId));
            }
        }

        [TestMethod]
        public async Task RemoveCocktailFromBar_Throws_When_Cocktail_NotFound_AtThisBar()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(RemoveCocktailFromBar_Throws_When_Cocktail_NotFound_AtThisBar));


            var bar = new Bar
            {
                Id = Guid.Parse("86cb5331-0035-4a52-b99b-08df779358e3"),
                Name = "Cosmos",
                Country = new Country
                {
                    Id = Guid.Parse("fb837576-a066-43a1-9812-3c1eac4d449c"),
                    Name = "Bulgaria"
                }
            };

            var cocktail = new Cocktail
            {
                Id = Guid.Parse("bb4b4175-81c5-4828-bca4-3660f796eb3f"),
                Name = "Manhattan",
            };

            var cocktailDTO = new CocktailDTO
            {
                Id = cocktail.Id,
                Name = cocktail.Name,

            };

            var barCocktail = new BarCocktail
            {
                Id = Guid.Parse("ca28a84e-1885-4d1b-aee9-3ab4f9ade0f7"),
                CocktailId = cocktail.Id
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

                await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => sut.RemoveCocktailFromBar(bar.Id, cocktailDTO.Id));
            }
        }

        [TestMethod]
        public async Task RemoveCocktailFromBar_Removes_Correct_When_Params_AreValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(RemoveCocktailFromBar_Removes_Correct_When_Params_AreValid));


            var bar = new Bar
            {
                Id = Guid.Parse("86cb5331-0035-4a52-b99b-08df779358e3"),
                Name = "Cosmos",
                Country = new Country
                {
                    Id = Guid.Parse("fb837576-a066-43a1-9812-3c1eac4d449c"),
                    Name = "Bulgaria",
                }
            };

            var cocktail = new Cocktail
            {
                Id = Guid.Parse("bb4b4175-81c5-4828-bca4-3660f796eb3f"),
                Name = "Manhattan",
            };

            var cocktailDTO = new CocktailDTO
            {
                Id = cocktail.Id,
                Name = cocktail.Name,

            };

            var barCocktail = new BarCocktail
            {
                Id = Guid.Parse("ca28a84e-1885-4d1b-aee9-3ab4f9ade0f7"),
                CocktailId = cocktail.Id,
                BarId = bar.Id
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
                var result = await sut.RemoveCocktailFromBar(bar.Id, cocktail.Id);

                Assert.AreEqual(0, result.BarCocktails.Count);
                Assert.IsInstanceOfType(result, typeof(BarDTO));
            }
        }
    }
}

//public async Task<BarDTO> RemoveCocktailFromBar(Guid barId, Guid cocktailId)
//{

//    var bar = await GetAllBarsQueryable()
//                    .Include(b => b.Country)
//                    .FirstOrDefaultAsync(b => b.Id == barId)
//                    ?? throw new ArgumentNullException("The Id of bar cannot be null");

//    var cocktail = await this.context.Cocktails
//                                     .FirstOrDefaultAsync(c => c.Id == cocktailId)
//                                     ?? throw new ArgumentNullException("The Id of bar cannot be null");


//    var barCocktail = await this.context.BarCocktails
//                                        .FirstOrDefaultAsync(bc => bc.BarId == barId && bc.CocktailId == cocktailId);

//    if (barCocktail != null)
//    {
//        barCocktail.IsListed = false;
//        barCocktail.ModifiedOn = DateTime.UtcNow;
//        bar.BarCocktails.Remove(barCocktail);
//        cocktail.Bars.Remove(barCocktail);

//        this.context.Update(barCocktail);
//        await this.context.SaveChangesAsync();
//    }
//    else
//    {
//        throw new InvalidOperationException($"{cocktail} was not found at {bar}");
//    }

//    return bar.GetDTO();
//}