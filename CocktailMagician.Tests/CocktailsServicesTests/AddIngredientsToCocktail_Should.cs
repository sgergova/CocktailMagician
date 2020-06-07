using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailsServicesTests
{
    [TestClass]
    public class AddIngredientsToCocktail_Should
    {
        [TestMethod]
        public async Task AddIngredientsToCocktail_Adds_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddIngredientsToCocktail_Adds_Correct));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Vodka" };
            var ingredient2 = new Ingredient { Id = Guid.NewGuid(), Name = "Rum" };
            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };

            ICollection<Guid> ingredientsId = new List<Guid> { ingredient.Id, ingredient2.Id };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddRangeAsync(ingredient, ingredient2);
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert 
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result = await sut.AddIngredientsToCocktail(cocktail.Id, ingredientsId);

                Assert.AreEqual(2, result.Ingredients.Count);
                Assert.AreEqual(2, assertContext.Ingredients.Count());
                Assert.AreEqual("Manhattan", result.Ingredients.ToList()[0].Cocktail.Name);
                Assert.AreEqual("Manhattan", result.Ingredients.ToList()[1].Cocktail.Name);
            }
        }
        [TestMethod]
        public async Task AddIngredientsToCocktail_Throws_When_NoCocktailFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddIngredientsToCocktail_Throws_When_NoCocktailFound));

            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Vodka" };
            var ingredient2 = new Ingredient { Id = Guid.NewGuid(), Name = "Rum" };
            var cocktailId = Guid.NewGuid();

            ICollection<Guid> ingredientsId = new List<Guid> { ingredient.Id, ingredient2.Id };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddRangeAsync(ingredient, ingredient2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert 
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.AddCocktailsToBar(cocktailId, ingredientsId));
            }
        }
    }
}
