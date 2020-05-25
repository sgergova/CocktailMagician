using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailsServicesTests
{
    [TestClass]
    public class DeleteCocktail_Should
    {
        [TestMethod]
        public async Task DeleteCocktail_Should_Delete_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(DeleteCocktail_Should_Delete_Correct));

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Dante", };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktail);
                await arrangeContext.SaveChangesAsync();
            }

            // Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);
                var result = await sut.DeleteCocktail(cocktail.Id);

                Assert.AreEqual(true, result.IsDeleted);
            }
        }


        [TestMethod]
        public async Task DeleteCocktail_Throws_WhenCocktailNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(DeleteCocktail_Throws_WhenCocktailNotFound));
            var id = Guid.NewGuid();

            // Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteCocktail(id));
            }
        }
    }
}
//public async Task<CocktailDTO> DeleteCocktail(Guid id)
//{
//    var cocktailToDelete = await GetCocktailsQueryable()
//                         .FirstOrDefaultAsync(b => b.Id == id)
//                         ?? throw new ArgumentNullException();

//    var barCocktails = AvailabilityAtBars(cocktailToDelete.Id).Result.GetEntities();

//    if (barCocktails.Count != 0)
//    {
//        foreach (var barCocktail in barCocktails)
//        {
//            cocktailToDelete.Bars.Remove(barCocktail);
//        }
//    }

//    cocktailToDelete.IsDeleted = true;
//    cocktailToDelete.DeletedOn = DateTime.UtcNow;

//    context.Cocktails.Update(cocktailToDelete);
//    await context.SaveChangesAsync();

//    return cocktailToDelete.GetDTO();