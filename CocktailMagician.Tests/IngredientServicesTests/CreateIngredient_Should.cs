using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.IngredientServicesTests
{
    [TestClass]
    public class CreateIngredient_Should
    {

        [TestMethod]
        public async Task CreateIngredient_Creates_Correct_WhenParams_AreValid()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(CreateIngredient_Creates_Correct_WhenParams_AreValid));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum" };
            var ingredientDTO = new IngredientDTO { Name = "Vodka", Description = "Alcoholic spirit", Quantity = 200};

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);
                var result = await sut.CreateIngredient(ingredientDTO);

                Assert.AreEqual("Vodka", result.Name);
                Assert.AreEqual("Alcoholic spirit", result.Description);
                Assert.AreEqual(200, result.Quantity);
                Assert.IsInstanceOfType(result, typeof(IngredientDTO));

            }
        }
        [TestMethod]
        public async Task CreateIngredient_Throws_When_NameIsExisting()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(CreateIngredient_Throws_When_NameIsExisting));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum" };
            var ingredientDTO = new IngredientDTO { Name = "Rum" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateIngredient(ingredientDTO));
            }
        }

        [TestMethod]
        public async Task CreateIngredient_Throws_When_NameIsNull()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(CreateIngredient_Throws_When_NameIsNull));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum" };
            var ingredientDTO = new IngredientDTO { Name = null };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateIngredient(ingredientDTO));
            }
        }
    }
}
