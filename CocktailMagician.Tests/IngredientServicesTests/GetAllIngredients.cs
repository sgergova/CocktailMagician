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

namespace CocktailMagician.Tests.IngredientServicesTests
{
    [TestClass]
    public class GetAllIngredients
    {
        [TestMethod]
        public async Task GetAllIngredients_Returns_OnlyExisting_Entities()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllIngredients_Returns_OnlyExisting_Entities));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum", Description = "Alcoholic spirit" };
            var ingredient2 = new Ingredient { Id = Guid.NewGuid(), Name = "Vodka", Description = "Alcoholic spirit" };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddRangeAsync(ingredient, ingredient2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);
                var result = await sut.GetAllIngredients(null);

                Assert.AreEqual(2, assertContext.Ingredients.Count());
                Assert.IsInstanceOfType(result, typeof(ICollection<IngredientDTO>));
            }
        }

        [TestMethod]
        public async Task GetAllIngredients_Returns_When_NameIsPassed()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllIngredients_Returns_When_NameIsPassed));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum", Description = "Alcoholic spirit" };
            var ingredient2 = new Ingredient { Id = Guid.NewGuid(), Name = "Vodka", Description = "Alcoholic spirit" };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddRangeAsync(ingredient, ingredient2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);
                var result = await sut.GetAllIngredients("VoDKa");

                Assert.AreEqual(1, result.Count());
                Assert.AreEqual("Vodka", result.ToList()[0].Name);
                Assert.AreEqual("Alcoholic spirit", result.ToList()[0].Description);

            }
        }
    }
}