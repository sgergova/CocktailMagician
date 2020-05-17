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
                Country = new Country
                {
                    Id = Guid.Parse("ae92c68c-778c-4c6c-a721-8ff208d0e0ba"),
                    Name = "USA"
                }
            };

            var bar2 = new Bar
            {
                Id = Guid.Parse("691cd199-fc90-4b80-971a-c53b218af997"),
                Name = "The Cocktail Bar",
                Country = new Country
                {
                    Id = Guid.Parse("67e746ba-e72c-4d67-bb7d-257bb30c5e0f"),
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
                var result = await sut.GetAllBars("Manhattan", 0, null, null);

                Assert.AreEqual(1, result.Count);
            }
        }

        [TestMethod]
        public async Task GetBars_Return_When_AddressPassed()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(GetBars_Return_When_AddressPassed));

            var bar = new Bar
            {
                Id = Guid.Parse("45e486a2-5390-44e6-9224-69f9a14d63ae"),
                Name = "Manhattan",
                Address = "USA",
                Country = new Country
                {
                    Id = Guid.Parse("e443b2e4-978a-4275-8327-54011c9c980e"),
                    Name = "Belgium"
                }
            };

            var bar2 = new Bar
            {
                Id = Guid.Parse("691cd199-fc90-4b80-971a-c53b218af997"),
                Name = "The Cocktail Bar",
                Address = "Sofia",
                 Country = new Country
                 {
                     Id = Guid.Parse("ae92c68c-778c-4c6c-a721-8ff208d0e0ba"),
                     Name = "USA"
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
                var result = await sut.GetAllBars(null, 0, "Sofia", null);

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
                var result = await sut.GetAllBars("Manhattan", 0, null, null);

                Assert.AreEqual(0, result.Count);
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
                Country = new Country
                {
                    Id = Guid.Parse("48de0284-4dff-47ac-982e-029348a44ba6"),
                    Name = "USA"
                }
            };

            var bar2 = new Bar
            {
                Id = Guid.Parse("691cd199-fc90-4b80-971a-c53b218af997"),
                Name = "The Cocktail Bar",
                Rating = 1,
                Country = new Country
                {
                    Id = Guid.Parse("9295edcc-2944-409d-9149-f81fb01b84b1"),
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
                var result = await sut.GetAllBars(null, 1, null, null);

                Assert.AreEqual(1, result.Count);
            }
        }

        [TestMethod]
        public async Task GetBars_Return_By_Given_Country()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(GetBars_Return_By_Given_Country));

            var bar = new Bar
            {
                Id = Guid.Parse("828d338a-e243-41d1-949c-45cc1b09f7f0"),
                Name = "Manhattan",
                Country = new Country
                {
                    Id = Guid.Parse("81e8b436-c542-4eaa-8a3c-f7335aa885d3"),
                    Name = "Bulgaria",
                }
            };

            var bar2 = new Bar
            {
                Id = Guid.Parse("691cd199-fc90-4b80-971a-c53b218af997"),
                Name = "The Cocktail Bar",
                Country = new Country
                {
                    Id = Guid.Parse("dfa61a0a-35f6-4645-8251-30bbc1ab9f06"),
                    Name = "Germany",
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
                var result = await sut.GetAllBars(null, 0, null, "Bulgaria");

                Assert.AreEqual(1, result.Count);
            }
        }
    }
}
