using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailsServicesTests
{
    [TestClass]
    public class SearchByAlcohol_Should
    {
        [TestMethod]
        public async Task SearchByAlchol_Returns_Correct_When_CriteriaIsValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SearchByAlchol_Returns_Correct_When_CriteriaIsValid));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cuba Libre", IsAlcoholic = false };
            var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "Margarita", IsAlcoholic = true };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.AddRangeAsync(cocktail, cocktail2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result = await sut.SearchByAlcohol("non-alcoholic");

                Assert.AreEqual(1, result.Count);
            }
        }
        [TestMethod]
        public async Task SearchByAlchol_Returns_OnlyExisting_Entities()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SearchByAlchol_Returns_OnlyExisting_Entities));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cuba Libre", IsAlcoholic = true };
            var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "Margarita", IsDeleted = true, IsAlcoholic = true };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.AddRangeAsync(cocktail, cocktail2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result = await sut.SearchByAlcohol("alcoholic");

                Assert.AreEqual(1, result.Count);
            }
        }
        [TestMethod]
        public async Task SearchByAlchol_Returns_Correct_Instance()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SearchByAlchol_Returns_Correct_Instance));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Cuba Libre", IsAlcoholic = false };
            var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "Margarita", IsAlcoholic = true };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.AddRangeAsync(cocktail, cocktail2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result = await sut.SearchByAlcohol("non-alcoholic");

                Assert.IsInstanceOfType(result, typeof(ICollection<CocktailDTO>));
            }
        }
        [TestMethod]
        public async Task SearchByAlchol_Throws_When_SearchCriteriaIsNull()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SearchByAlchol_Throws_When_SearchCriteriaIsNull));

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.SearchByAlcohol(null));
            }
        }
    }
}
//public async Task<ICollection<CocktailDTO>> SearchByAlcohol(string criteria)
//{
//    if (criteria == null)
//        throw new ArgumentNullException("You should enter your criteria");

//    var cocktails = this.context.Cocktails
//                                    .Where(c => c.IsDeleted == false)
//                                    .AsQueryable();

//    if (criteria == "non-alcoholic")
//        cocktails = cocktails.Where(c => c.IsAlcoholic == false);

//    if (criteria == "alcoholic")
//        cocktails = cocktails.Where(c => c.IsAlcoholic == true);


//    var cocktailsToReturn = await cocktails.ToListAsync();
//    return cocktailsToReturn.GetDTOs();
//}