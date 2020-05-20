using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
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
    public class UpdateIngredient_Should
    {
        [TestMethod]
        public async Task UpdateIngredient_Updates_Correct()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(UpdateIngredient_Updates_Correct));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rummm" };
            var ingredientDTO = new IngredientDTO { Name = "Rum", Description = "Alcoholic spirit", Quantity = 200 };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);
                var result = await sut.UpdateIngredient(ingredient.Id, ingredientDTO);

                Assert.AreEqual("Rum", result.Name);
                Assert.AreEqual("Alcoholic spirit", result.Description);
                Assert.AreEqual(200, result.Quantity);
                Assert.IsInstanceOfType(result, typeof(IngredientDTO));

            }
        }

        [TestMethod]
        public async Task UpdateIngredient_Throws_WhenIngredientNotFound()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(UpdateIngredient_Throws_WhenIngredientNotFound));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum" };
            var ingredientDTO = new IngredientDTO { Name = "Rum" };
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

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.UpdateIngredient(id, ingredientDTO));
            }
        }
    }
}
