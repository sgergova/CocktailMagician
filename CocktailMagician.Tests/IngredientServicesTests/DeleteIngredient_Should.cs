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
   public class DeleteIngredient_Should
    {

        [TestMethod]
        public async Task DeleteIngredient_Should_DeleteCorrect()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(DeleteIngredient_Should_DeleteCorrect));

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
                var result = await sut.DeleteIngredient(ingredient.Id);

                Assert.AreEqual(true, result.IsDeleted);
                Assert.IsInstanceOfType(result, typeof(IngredientDTO));
            }
        }

        [TestMethod]
        public async Task DeleteIngredient_Should_Delete_CocktailIngredients()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(DeleteIngredient_Should_Delete_CocktailIngredients));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cuba Libre" };
            var ingredient = new Ingredient { Id = Guid.NewGuid(), Name = "Rum", Description = "Alcoholic spirit" };
            var cocktailIngredient = new CocktailIngredient {CocktailId = cocktail.Id, IngredientId = ingredient.Id };

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
                var result = await sut.DeleteIngredient(ingredient.Id);

                Assert.AreEqual(0, result.CocktailIngredients.Count);
            }
        }

        [TestMethod]
        public async Task DeleteIngredient_Throws_When_IngredientNotFound()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(DeleteIngredient_Throws_When_IngredientNotFound));

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

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteIngredient(id));
            }
        }
    }
}
