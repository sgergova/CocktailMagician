using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
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

            var barID = Guid.Parse("65e6f2f3-a2a3-47da-b5e9-966085c05731");

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.AddCocktailToBar(barID, null));
            }

        }
        [TestMethod]
        public async Task AddCocktailToBar_Throws_When_BarCocktail_IsNotNull()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddCocktailToBar_Throws_When_BarCocktail_IsNotNull));

            var barID = Guid.Parse("65e6f2f3-a2a3-47da-b5e9-966085c05731");
            var cocktailId = Guid.Parse("42b312f9-09c9-435a-a82a-3b4d1f027234");


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

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.AddCocktailToBar(barID, cocktailDTO));
            }

        }

        [TestMethod]
        public async Task AddCocktailToBar_Adds_Correctly_When_Params_Are_Valid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddCocktailToBar_Adds_Correctly_When_Params_Are_Valid));


            var bar = new Bar
            {
                Id = Guid.Parse("65e6f2f3-a2a3-47da-b5e9-966085c05731"),
                Name = "Cosmos",
                Country = new Country
                {
                    Id = Guid.Parse("a7db8a1a-e036-4de8-b673-7ece0aecf043"),
                    Name = "Bulgaria"
                }
            };

            var cocktail = new Cocktail
            {
                Id = Guid.Parse("42b312f9-09c9-435a-a82a-3b4d1f027234"),
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
                var result = await sut.AddCocktailToBar(bar.Id, cocktailDTO);

                Assert.AreEqual(1, assertContext.BarCocktails.Count());
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
                BarId = bar.Id,
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

                await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => sut.AddCocktailToBar(bar.Id, cocktailDTO));
            }

        }
    }

}

//public async Task<BarDTO> AddCocktailToBar(Guid barId, CocktailDTO cocktail)
//{
//    var bar = await GetAllBarsQueryable()
//                         .FirstOrDefaultAsync(b => b.Id == barId)
//                         ?? throw new ArgumentNullException();

//    var cocktailToAdd = cocktail.GetEntity();

//    var barCocktail = await this.context.BarCocktails
//                                    .FirstOrDefaultAsync(bc => bc.BarId == barId && bc.CocktailId == cocktail.Id);

//    if (barCocktail != null)
//        throw new InvalidOperationException($"The cocktail is already listed on {bar}");


//    if (barCocktail == null)
//    {
//        var newBarCocktail = new BarCocktail
//        {
//            Bar = bar,
//            Cocktail = cocktailToAdd,
//            IsListed = true
//        };
//        context.Cocktails.Update(cocktailToAdd);
//        await context.BarCocktails.AddAsync(newBarCocktail);
//        await context.SaveChangesAsync();
//    }
//    else
//    {
//        throw new InvalidOperationException("This cocktail is already in this bar.");
//    }

//    return bar.GetDTO();
//}
