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
				var result = await sut.GetIndexPageBars(1, "The");

				Assert.AreEqual(1, result.Count);
				Assert.AreEqual(bar2.Id, result.ToList()[0].Id);
				Assert.AreEqual(bar2.Name, result.ToList()[0].Name);
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
				var result = await sut.GetIndexPageBars(1, null);

				Assert.AreEqual(2, result.Count);
			}
		}
		[TestMethod]
		public async Task GetIndexPageBars_ShouldReturn_Correct_When_SearchByName_IsPassed()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageBars_ShouldReturn_Correct_When_SearchByName_IsPassed));
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
				var result = await sut.GetIndexPageBars(1, "Manhattan");

				Assert.AreEqual(1, result.Count);
				Assert.AreEqual(bar.Id, result.ToList()[0].Id);
				Assert.AreEqual(bar.Name, result.ToList()[0].Name);

			}
		}
		[TestMethod]
		public async Task GetIndexPageBars_ShouldReturn_Correct_When_SearchByCountry_IsPassed()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageBars_ShouldReturn_Correct_When_SearchByCountry_IsPassed));
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
				var result = await sut.GetIndexPageBars(1, "Belguim");

				Assert.AreEqual(1, result.Count);
				Assert.AreEqual(bar2.Id, result.ToList()[0].Id);
				Assert.AreEqual(bar2.Name, result.ToList()[0].Name);
				Assert.AreEqual(bar2.Country.Name, result.ToList()[0].CountryName);

			}
		}

		[TestMethod]
		public async Task GetIndexPageBars_ShouldReturn_Correct_When_SearchByAddress_IsPassed()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageBars_ShouldReturn_Correct_When_SearchByAddress_IsPassed));
			var bar = new Bar
			{
				Id = Guid.NewGuid(),
				Name = "Manhattan",
				Address = "Liditse 18",
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
				Address = "Maria Luyza 20",
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
				var result = await sut.GetIndexPageBars(1, "Maria");

				Assert.AreEqual(1, result.Count);
				Assert.AreEqual(bar2.Id, result.ToList()[0].Id);
				Assert.AreEqual(bar2.Name, result.ToList()[0].Name);
				Assert.AreEqual(bar2.Country.Name, result.ToList()[0].CountryName);
				Assert.AreEqual(bar2.Address, result.ToList()[0].Address);
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
				var result = await sut.GetIndexPageBars(0, null);

				Assert.AreEqual(1, result.Count);
				Assert.AreEqual(bar2.Name, result.ToList()[0].Name);
			}
		}

		[TestMethod]
		public async Task GetIndexPageBars_Returns_Correct_WhenMoreThanOne_EntityFound()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageBars_Returns_Correct_WhenMoreThanOne_EntityFound));
			var bar = new Bar
			{
				Id = Guid.NewGuid(),
				Name = "Manhattan",
				Country = new Country
				{
					Id = Guid.NewGuid(),
					Name = "USA",
				}
			};
			var bar2 = new Bar
			{
				Id = Guid.NewGuid(),
				Name = "The Mall Coffee",
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
				var result = await sut.GetIndexPageBars(0, "Ma");

				Assert.AreEqual(2, result.Count);
				Assert.AreEqual(bar.Name, result.ToList()[0].Name);
				Assert.AreEqual(bar.Country.Name, result.ToList()[0].CountryName);
				Assert.AreEqual(bar2.Name, result.ToList()[1].Name);
				Assert.AreEqual(bar2.Country.Name, result.ToList()[1].CountryName);
				Assert.IsInstanceOfType(result, typeof(ICollection<BarDTO>));
			}
		}

	}
}
