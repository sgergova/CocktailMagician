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
    public class GetIndexPageIngredients_Should
    {
        [TestMethod]
        public async Task GetIndexPageIngredient_Retuns_Correct_When_ParamsAreValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetIndexPageIngredient_Retuns_Correct_When_ParamsAreValid));
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
                var result = await sut.GetIndexPageIngredients("name", 1, "V");

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(result.ToList()[0].Id, ingredient.Id);
                Assert.AreEqual(result.ToList()[0].Name, ingredient.Name);
                Assert.IsInstanceOfType(result, typeof(ICollection<IngredientDTO>));
            }
        }

        [TestMethod]
        public async Task GetIndexPageIngredient_Returns_Correct_When_NoParams_ArePassed()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetIndexPageIngredient_Returns_Correct_When_NoParams_ArePassed));
           
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
                var result = await sut.GetIndexPageIngredients(null, 1, null);

                Assert.AreEqual(2, result.Count);
            }
        }

        [TestMethod]
        public async Task GetIndexPageIngredients_Returns_Only_ExistingInstances()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetIndexPageIngredients_Returns_Only_ExistingInstances));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Vodka", IsDeleted = true };
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
                var result = await sut.GetIndexPageIngredients(null, 0, null);

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(result.ToList()[0].Name, ingredient2.Name);
                Assert.AreEqual(result.ToList()[0].Id, ingredient2.Id);

            }
        }
    }
}
