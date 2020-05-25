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
    public class AvailabilityAtCocktails_Should
    {
        [TestMethod]
        public async Task AvailabilityAtCocktails_Returns_Correct()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(AvailabilityAtCocktails_Returns_Correct));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cuba Libre" };
            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum", Description = "Alcoholic spirit" };
            var cocktailIngredient = new CocktailIngredient { CocktailId = cocktail.Id, IngredientId = ingredient.Id, IsDeleted = true };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(ingredient);
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.CocktailIngredients.AddAsync(cocktailIngredient);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientServices(assertContext);
                var result = await sut.AvailabilityAtCocktails(ingredient.Id);

                Assert.AreEqual(0, result.Count);
                Assert.IsInstanceOfType(result, typeof(ICollection<CocktailIngredientDTO>));
            }
        }
    }
}

