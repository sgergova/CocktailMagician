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

namespace CocktailMagician.Tests.CocktailsServicesTests
{
    [TestClass]
    public class AddIngredientToCocktail_Should
    {

        [TestMethod]
        public async Task AddIngredientToCocktail_AddsCorrect()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddIngredientToCocktail_AddsCorrect));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cuba Libre" };
            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert 
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result =  await sut.AddIngredientToCocktail(cocktail.Name, ingredient.Name);

                Assert.AreEqual(1, assertContext.CocktailIngredients.Count());
                Assert.AreEqual(1, result.Ingredients.Count());
                Assert.IsInstanceOfType(result, typeof(CocktailDTO));
            }
        }

        [TestMethod]
        public async Task AddIngredientToCocktail_Throws_When_Ingredient_IsAdded()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddIngredientToCocktail_Throws_When_Ingredient_IsAdded));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cuba Libre" };
            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum" };
            var cocktailIngredient = new CocktailIngredient { CocktailId = cocktail.Id, IngredientId = ingredient.Id };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.CocktailIngredients.AddAsync(cocktailIngredient);
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert 
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);

                await Assert.ThrowsExceptionAsync<InvalidOperationException>(()
                                                  => sut.AddIngredientToCocktail(cocktail.Name, ingredient.Name));
            }
        }

        [TestMethod]
        public async Task AddIngredientToCocktail_Throws_When_CocktailNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddIngredientToCocktail_Throws_When_CocktailNotFound));

            var ingredientName = "Rum";
            var cocktailName = "Cuba Libre";

            //Act, Assert 
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() 
                                                        => sut.AddIngredientToCocktail(cocktailName, ingredientName));
            }
        }

        [TestMethod]
        public async Task AddIngredientToCocktail_Throws_When_IngredientNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddIngredientToCocktail_Throws_When_IngredientNotFound));

            var ingredientName = "Rum";
            var cocktailName = "Cuba Libre";

            //Act, Assert 
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(()
                                                        => sut.AddIngredientToCocktail(cocktailName, ingredientName));
            }
        }
    }
}
