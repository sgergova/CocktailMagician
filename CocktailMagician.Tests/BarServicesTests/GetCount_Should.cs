using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarServicesTests
{
    [TestClass]
   public class GetCount_Should
    {
		[TestMethod]
		public async Task GetCount_Should_ReturnCorrect_When_No_Params_Are_Passed()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetCount_Should_ReturnCorrect_When_No_Params_Are_Passed));

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
				await arrangeContext.Bars.AddRangeAsync(bar, bar2);
				await arrangeContext.SaveChangesAsync();
			};

			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new BarServices(assertContext);
				var result = sut.GetCount(1);

				Assert.AreEqual(2, result);
			}
		}
	}
}


