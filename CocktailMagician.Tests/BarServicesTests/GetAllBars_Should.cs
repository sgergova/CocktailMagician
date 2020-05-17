using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services;
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
                Id = Guid.Parse("828d338a-e243-41d1-949c-45cc1b09f7f0"),
                Name = "Manhattan",
            };

            var bar2 = new Bar
            {
                Id = Guid.Parse("691cd199-fc90-4b80-971a-c53b218af997"),
                Name = "The Cocktail Bar",
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
                var result = await sut.GetAllBars("Manhattan", 0, null);

                Assert.AreEqual(result.Count, 1);
            }
        }

        [TestMethod]
        public async Task GetBars_Return_When_AddressPassed()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(GetBars_Return_When_AddressPassed));

            var bar = new Bar
            {
                Id = Guid.Parse("828d338a-e243-41d1-949c-45cc1b09f7f0"),
                Name = "Manhattan",
                Address = "USA"
            };

            var bar2 = new Bar
            {
                Id = Guid.Parse("691cd199-fc90-4b80-971a-c53b218af997"),
                Name = "The Cocktail Bar",
                Address = "Sofia"
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
                var result = await sut.GetAllBars(null, 0, "Sofia");

                Assert.AreEqual(result.Count, 1);
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
                IsDeleted = true
            };

            var bar2 = new Bar
            {
                Id = Guid.Parse("691cd199-fc90-4b80-971a-c53b218af997"),
                Name = "The Cocktail Bar",
                Address = "Sofia"
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
                var result = await sut.GetAllBars("Manhattan", 0, null);

                Assert.AreEqual(result.Count, 0);
            }
        }

        [TestMethod]
        public async Task GetBars_Return_DTO_With_Current_Rating()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(GetBars_Return_DTO_With_Current_Rating));

            var bar = new Bar
            {
                Id = Guid.Parse("828d338a-e243-41d1-949c-45cc1b09f7f0"),
                Name = "Manhattan",
                IsDeleted = true
            };

            var bar2 = new Bar
            {
                Id = Guid.Parse("691cd199-fc90-4b80-971a-c53b218af997"),
                Name = "The Cocktail Bar",
                Address = "Sofia",
                Rating = 1
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
                var result = await sut.GetAllBars(null, 1, null);

                Assert.AreEqual(result.Count, 1);
            }
        }
    }
}
