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
        public async Task GetBars_Return_When_NamePassed()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(GetBars_Return_When_NamePassed));

            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Manhattan",
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
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Belguim"
                }
            };

            using(var arrangeContext = new CMContext(options))
            {
                await arrangeContext.AddRangeAsync(bar, bar2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using(var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = await sut.GetAllBars("Manhattan");

                Assert.AreEqual(1, result.Count);
            }
        }

       
        [TestMethod]
        public async Task GetBars_Return_Only_ExistingEntities()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(GetBars_Return_Only_ExistingEntities));

            var bar = new Bar
            {
                Id = Guid.Parse("828d338a-e243-41d1-949c-45cc1b09f7f0"),
                Name = "Manhattan",
                IsDeleted = true,
                Country = new Country
                {
                    Id = Guid.Parse("8cb1d0cf-010a-436c-864f-4c1d3d1be8a4"),
                    Name = "USA"
                }

            };

            var bar2 = new Bar
            {
                Id = Guid.Parse("691cd199-fc90-4b80-971a-c53b218af997"),
                Name = "The Cocktail Bar",
                Address = "Sofia",
                Country = new Country
                {
                    Id = Guid.Parse("d30d6f12-4831-4d55-9c90-81ded6d42c5c"),
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
                var result = await sut.GetAllBars("Manhattan");

                Assert.AreEqual(0, result.Count);
            }
        }
      
        [TestMethod]
        public async Task GetBars_Returns_Correct_Instance()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(GetBars_Returns_Correct_Instance));

            var bar = new Bar
            {
                Id = Guid.Parse("fabec5dc-1282-48d8-a768-cf78b17e390c"),
                Name = "Manhattan",
                Country = new Country
                {
                    Id = Guid.Parse("45080ff0-0cd8-4786-ad3c-9a3becdaf90c"),
                    Name = "Bulgaria",
                }
            };

            var bar2 = new Bar
            {
                Id = Guid.Parse("c7d91283-7399-45f2-a185-598da9780480"),
                Name = "The Cocktail Bar",
                Country = new Country
                {
                    Id = Guid.Parse("58abfbca-9e8c-4e98-8925-08eac637a513"),
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
                var result = await sut.GetAllBars("Bulgaria");

                Assert.IsInstanceOfType(result, typeof(ICollection<BarDTO>));
            }
        }
    }
}
