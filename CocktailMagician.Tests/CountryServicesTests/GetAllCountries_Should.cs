using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
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
    public class GetAllCountries_Should
    {
        [TestMethod]
        public async Task GetAllCountries_Returns_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCountries_Returns_Correct));

            var country = new Country { Id = Guid.NewGuid(), Name = "Bulgaria" };
            var country2 = new Country { Id = Guid.NewGuid(), Name = "Japan" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Countries.AddRangeAsync(country, country2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);
                var result = sut.GetAllCountries();

                Assert.AreEqual(2, result.Result.Count);
                Assert.IsInstanceOfType(result.Result, typeof(ICollection<CountryDTO>));
            }
        }

        [TestMethod]
        public async Task GetAllCountries_Returns_Only_ExistingInstances()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCountries_Returns_Only_ExistingInstances));

            var country = new Country { Id = Guid.NewGuid(), Name = "Bulgaria", IsDeleted = true };
            var country2 = new Country { Id = Guid.NewGuid(), Name = "Japan" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Countries.AddRangeAsync(country, country2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);
                var result = sut.GetAllCountries();

                Assert.AreEqual(1, result.Result.Count);

            }
        }
    }
}
