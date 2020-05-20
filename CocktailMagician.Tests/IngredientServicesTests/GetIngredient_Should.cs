using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
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
   public class GetIngredient_Should
    {
        [TestMethod]
        public async Task GetIngredient_Returns_When_ParamsAreValid()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(GetIngredient_Returns_When_ParamsAreValid));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum", Description = "Alcoholic spirit" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);
                var result = await sut.GetIngredient(ingredient.Id);

                Assert.AreEqual(1, assertContext.Ingredients.Count());
                Assert.AreEqual("Rum", result.Name);
                Assert.AreEqual("Alcoholic spirit", result.Description);
                Assert.IsInstanceOfType(result, typeof(IngredientDTO));
            }
        }

        [TestMethod]
        public async Task GetIngredient_Returns_When_ValidNameIsPassed()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(GetIngredient_Returns_When_ValidNameIsPassed));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum", Description = "Alcoholic spirit" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);
                var result = await sut.GetIngredient(ingredient.Name);

                Assert.AreEqual("Rum", result.Name);
                Assert.AreEqual("Alcoholic spirit", result.Description);
                Assert.IsInstanceOfType(result, typeof(IngredientDTO));
            }
        }

        [TestMethod]
        public async Task GetIngredient_Throws_When_Ingredient_NotValidNameIsPassed()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(GetIngredient_Throws_When_Ingredient_NotValidNameIsPassed));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum", Description = "Alcoholic spirit" };
            var id = Guid.NewGuid();

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetIngredient("Vodka"));
            }
        }

        [TestMethod]
        public async Task GetIngredient_Throws_When_Ingredient_NotFound()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(GetIngredient_Throws_When_Ingredient_NotFound));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum", Description = "Alcoholic spirit" };
            var id = Guid.NewGuid();

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetIngredient(id));
            }
        }
    }
}
