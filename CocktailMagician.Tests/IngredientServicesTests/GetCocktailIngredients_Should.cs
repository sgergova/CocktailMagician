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
  public  class GetCocktailIngredients_Should
    {
        [TestMethod]
        public async Task GetCocktailIngredients_Returns_WhenParamIsValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetCocktailIngredients_Returns_WhenParamIsValid));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Vodka" };
            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "Margarita" };
            var cocktailIngredient = new CocktailIngredient { IngredientId = ingredient.Id, CocktailId = cocktail.Id };
            var cocktailIngredient2 = new CocktailIngredient { IngredientId = ingredient.Id, CocktailId = cocktail2.Id };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.Cocktails.AddRangeAsync(cocktail, cocktail2);
                await arrangeContext.CocktailIngredients.AddRangeAsync(cocktailIngredient, cocktailIngredient2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);
                var result = await sut.GetCocktailIngredients(cocktail.Id);

                Assert.AreEqual(cocktail.Id, result.ToList()[0].CocktailId);
                Assert.AreEqual(ingredient.Id, result.ToList()[0].IngredientId);
                Assert.AreEqual(ingredient.Name, result.ToList()[0].Ingredient.Name);
                Assert.AreEqual(cocktail.Name, result.ToList()[0].Cocktail.Name);
                Assert.IsInstanceOfType(result, typeof(ICollection<CocktailIngredientDTO>));
            }
        }
    }
}
