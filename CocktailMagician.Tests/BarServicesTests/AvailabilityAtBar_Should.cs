using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarServicesTests
{
    [TestClass]
    public class AvailabilityAtBar_Should
    {
        [TestMethod]
        public async Task AvailabilityAtBar_Return_Correct()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(AvailabilityAtBar_Return_Correct));

            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Manhattan",
                Country = new Country  { Id = Guid.NewGuid(), Name = "USA" }
            };
            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cosmopolitan" };

            var barCocktail2 = new BarCocktail { BarId = Guid.NewGuid(), CocktailId = cocktail.Id };
            var barCocktail = new BarCocktail { BarId = bar.Id, CocktailId = cocktail.Id, IsListed = true };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.BarCocktails.AddRangeAsync(barCocktail, barCocktail2);
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = await sut.AvailabilityAtBar(bar.Id);

                Assert.AreEqual(1, result.Count());
                Assert.AreEqual(result.ToList()[0].BarId, bar.Id);
            }
        }
    }
}
