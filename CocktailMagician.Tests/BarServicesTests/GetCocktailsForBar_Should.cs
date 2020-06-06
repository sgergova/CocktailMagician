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

namespace CocktailMagician.Tests.BarServicesTests
{
    [TestClass]
    public class GetCocktailsForBar_Should
    {
        [TestMethod]
        public async Task GetCocktailsForBar_Returns_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetCocktailsForBar_Returns_Correct));

            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Cosmos",
                Address = "Sofia",
                Rating = 2,
                Country = new Country { Name = "Bulgaria" }
            };
            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "Cosmopolitan" };
            var barCocktail = new BarCocktail { BarId = bar.Id, CocktailId = cocktail.Id };
            var barCocktail2 = new BarCocktail { BarId = bar.Id, CocktailId = cocktail2.Id };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Cocktails.AddRangeAsync(cocktail, cocktail2);
                await arrangeContext.BarCocktails.AddRangeAsync(barCocktail, barCocktail2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = await sut.GetCocktailsForBar(bar.Id);

                Assert.AreEqual(2, result.Count());
                Assert.AreEqual(barCocktail.CocktailId, result.ToList()[0].CocktailId);
                Assert.AreEqual(barCocktail.BarId, result.ToList()[0].BarId);
                Assert.AreEqual(barCocktail2.BarId, result.ToList()[1].BarId);
                Assert.AreEqual(barCocktail2.BarId, result.ToList()[1].BarId);
                Assert.IsInstanceOfType(result, typeof(ICollection<BarCocktailDTO>));

            }
        }
    }
}
