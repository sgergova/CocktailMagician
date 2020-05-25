using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CountryServicesTests
{
    [TestClass]
    public class DeleteCountry_Should
    {
        [TestMethod]
        public async Task DeleteCountry_ShouldDelete_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(DeleteCountry_ShouldDelete_Correct));

            var country = new Country { Id = Guid.NewGuid(), Name = "Germany" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Countries.AddAsync(country);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);
                var result = await sut.DeleteCountry(country.Id);

                Assert.AreEqual(true, result.IsDeleted);
                Assert.IsInstanceOfType(result, typeof(CountryDTO));
            }
        }

        [TestMethod]
        public async Task DeleteCountry_Throws_WhenCountryNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(DeleteCountry_Throws_WhenCountryNotFound));

            var id = Guid.NewGuid();


            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteCountry(id));
            }
        }
    }
}
//public async Task<CountryDTO> DeleteCountry(Guid id)
//{
//    var countryToDelete = await GetCountriesQuerable()
//                                       .FirstOrDefaultAsync(c => c.Id == id);

//    var barsAvailable = BarsAvailable(countryToDelete.Id).Result.GetEntities();

//    countryToDelete.IsDeleted = true;
//    countryToDelete.DeletedOn = DateTime.UtcNow;

//    if (barsAvailable.Count != 0)
//    {
//        foreach (var bar in barsAvailable)
//        {
//            countryToDelete.Bars.Remove(bar);
//        }
//    }
//    context.Countries.Update(countryToDelete);
//    await context.SaveChangesAsync();


//    return countryToDelete.GetDTO();
//}