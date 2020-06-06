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

namespace CocktailMagician.Tests.CocktailsServicesTests
{

    [TestClass]
    public class GetBarsOfCocktail_Should
    {
        [TestMethod]
        public async Task GetBarsOfCocktail_Returns_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetBarsOfCocktail_Returns_Correct));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cuba Libre" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Rabbit Hole" };
            var bar2 = new Bar { Id = Guid.NewGuid(), Name = "Cosmos" };

            var barCocktail = new BarCocktail { BarId = bar.Id, CocktailId = cocktail.Id, IsListed = true };
            var barCocktail2 = new BarCocktail { BarId = bar2.Id, CocktailId = cocktail.Id, IsListed = true };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.Bars.AddRangeAsync(bar, bar2);
                await arrangeContext.BarCocktails.AddRangeAsync(barCocktail, barCocktail2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result = await sut.GetBarsOfCocktail(cocktail.Id);

                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(barCocktail.BarId, result.ToList()[0].BarId);
                Assert.AreEqual(barCocktail.CocktailId, result.ToList()[0].CocktailId);
                Assert.AreEqual(barCocktail2.BarId, result.ToList()[1].BarId);
                Assert.AreEqual(barCocktail2.CocktailId, result.ToList()[1].CocktailId);
                Assert.IsInstanceOfType(result, typeof(ICollection<BarCocktailDTO>));
            }
        }

        [TestMethod]
        public async Task GetBarsOfCocktail_Returns_OnlyExistingEntities()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetBarsOfCocktail_Returns_OnlyExistingEntities));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cuba Libre" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Rabbit Hole" };
            var bar2 = new Bar { Id = Guid.NewGuid(), Name = "Cosmos" };

            var barCocktail = new BarCocktail { BarId = bar.Id, CocktailId = cocktail.Id, IsDeleted = false };
            var barCocktail2 = new BarCocktail { BarId = bar2.Id, CocktailId = cocktail.Id, IsListed = true };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.Bars.AddRangeAsync(bar, bar2);
                await arrangeContext.BarCocktails.AddRangeAsync(barCocktail, barCocktail2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result = await sut.GetBarsOfCocktail(cocktail.Id);

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(barCocktail2.BarId, result.ToList()[0].BarId);
                Assert.AreEqual(barCocktail2.CocktailId, result.ToList()[0].CocktailId);
                Assert.IsInstanceOfType(result, typeof(ICollection<BarCocktailDTO>));
            }
        }
    }
}
