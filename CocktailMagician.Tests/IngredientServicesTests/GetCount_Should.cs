using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.IngredientServicesTests
{
	[TestClass]
   public class GetCount_Should
    {
		[TestMethod]
		public async Task GetCount_Should_ReturnCorrect_When_No_Params_Are_Passed()
		{
			//Arrange
			//Arrange
			var options = Utils.GetOptions(nameof(GetCount_Should_ReturnCorrect_When_No_Params_Are_Passed));

			var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Vodka" };
			var ingredient2 = new Ingredient { Id = Guid.NewGuid(), Name = "Rum" };


			using (var arrangeContext = new CMContext(options))
			{
				await arrangeContext.Ingredients.AddRangeAsync(ingredient, ingredient2);
				await arrangeContext.SaveChangesAsync();
			};

			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new IngredientServices(assertContext);
				var result = sut.GetCount(0, null);

				Assert.AreEqual(2, result);
			}
		}
	}
}
