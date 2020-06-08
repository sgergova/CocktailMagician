using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CocktailMagician.Tests.BarServicesTests
{
    [TestClass]
   public class GetAllBars_Should
    {
      
        [TestMethod]
        public async Task GetBars_Return_Only_ExistingEntities()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(GetBars_Return_Only_ExistingEntities));

            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Manhattan",
                IsDeleted = true,
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "USA"
                }

            };

            var bar2 = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "The Cocktail Bar",
                Address = "Sofia",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Bulgaria"
                }
            };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.AddRangeAsync(bar, bar2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = await sut.GetAllBars();

                Assert.AreEqual(1, result.Count);
            }
        }
      
        [TestMethod]
        public async Task GetBars_Returns_Correct_Instance()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(GetBars_Returns_Correct_Instance));

            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Manhattan",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Bulgaria",
                }
            };

            var bar2 = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "The Cocktail Bar",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Bulgaria",
                }
            };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.AddRangeAsync(bar, bar2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = await sut.GetAllBars();

                Assert.IsInstanceOfType(result, typeof(ICollection<BarDTO>));
            }
        }
    }
}
