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
    public class GetIndexPagesBars_Should
    {
        [TestMethod]
        public async Task GetIndexPageBars_Retuns_Correct_When_ParamsAreValid()
        {
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageBars_Retuns_Correct_When_ParamsAreValid));
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

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.AddRangeAsync(bar, bar2);
                await arrangeContext.SaveChangesAsync();
            };
            
			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new BarServices(assertContext);
                var result = await sut.GetIndexPageBars("name", 1, "The");

				Assert.AreEqual(result.Count, 1);
				Assert.AreEqual(result.ToList()[0].Id, bar2.Id);
				Assert.AreEqual(result.ToList()[0].Name, bar2.Name);
                Assert.IsInstanceOfType(result, typeof(ICollection<BarDTO>));
			}
		}

		[TestMethod]
		public async Task GetIndexPageBars_ShouldReturn_Correct_When_NoParams_ArePassed()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageBars_ShouldReturn_Correct_When_NoParams_ArePassed));
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

			using (var arrangeContext = new CMContext(options))
			{
				await arrangeContext.AddRangeAsync(bar, bar2);
				await arrangeContext.SaveChangesAsync();
			};

			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new BarServices(assertContext);
				var result = await sut.GetIndexPageBars(null, 1, null);

				Assert.AreEqual(result.Count, 2);
			}
		}
		[TestMethod]
		public async Task GetIndexPageBars_ShouldReturn_Correct_When_OnlySearch_IsPassed()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageBars_ShouldReturn_Correct_When_OnlySearch_IsPassed));
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

			using (var arrangeContext = new CMContext(options))
			{
				await arrangeContext.AddRangeAsync(bar, bar2);
				await arrangeContext.SaveChangesAsync();
			};
			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new BarServices(assertContext);
				var result = await sut.GetIndexPageBars(null, 1, "Belguim");

				Assert.AreEqual(result.Count, 1);
				Assert.AreEqual(result.ToList()[0].Id, bar2.Id);
				Assert.AreEqual(result.ToList()[0].Name, bar2.Name);
				
			}
		}

		[TestMethod]
		public async Task GetIndexPageBars_ShouldReturn_Correct_When_OnlySort_IsPassed()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageBars_ShouldReturn_Correct_When_OnlySort_IsPassed));
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

			using (var arrangeContext = new CMContext(options))
			{
				await arrangeContext.AddRangeAsync(bar, bar2);
				await arrangeContext.SaveChangesAsync();
			};
			
			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new BarServices(assertContext);
				var result = await sut.GetIndexPageBars("name", 1, null);

				Assert.AreEqual(result.Count, 2);
				Assert.AreEqual(result.ToList()[0].Id, bar.Id);
				Assert.AreEqual(result.ToList()[0].Name, bar.Name);
				Assert.AreEqual(result.ToList()[1].Id, bar2.Id);
				Assert.AreEqual(result.ToList()[1].Name, bar2.Name);
			}
		}

		[TestMethod]
		public async Task GetIndexPageBars_Returns_Only_ExistingInstances()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageBars_Returns_Only_ExistingInstances));
			var bar = new Bar
			{
				Id = Guid.NewGuid(),
				Name = "Manhattan",
				IsDeleted = true,
				Country = new Country
				{
					Id = Guid.NewGuid(),
					Name = "USA",
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

			using (var arrangeContext = new CMContext(options))
			{
				await arrangeContext.AddRangeAsync(bar, bar2);
				await arrangeContext.SaveChangesAsync();
			};

			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new BarServices(assertContext);
				var result = await sut.GetIndexPageBars(null, 0, null);

				Assert.AreEqual(result.Count, 1);
				Assert.AreEqual(result.ToList()[0].Name, bar2.Name);
			}
		}

	}
}
