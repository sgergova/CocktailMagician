using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailsServicesTests
{
    [TestClass]
    public class UpdateCocktail_Should
    {
        [TestMethod]
        public async Task UpdateCocktail_Updates_Correct()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(UpdateCocktail_Updates_Correct));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cuba Libre" };
            var cocktailDTO = new CocktailDTO { Name = "Cuba Libre Indeed", AlcoholPercentage = 2.5, IsAlcoholic = true };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContex = new CMContext(options))
            {
                var sut = new CocktailServices(assertContex);
                var result = await sut.UpdateCocktail(cocktail.Id, cocktailDTO);

                Assert.AreEqual("Cuba Libre Indeed", result.Name);
                Assert.AreEqual(2.5, result.AlcoholPercentage);
                Assert.AreEqual(true, result.IsAlcoholic);
                Assert.IsInstanceOfType(result, typeof(CocktailDTO));

            }
        }
    }
}
