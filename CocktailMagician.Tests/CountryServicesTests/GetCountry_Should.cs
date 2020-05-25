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
   public class GetCountry_Should
    {
        [TestMethod]
        public async Task GetCountry_Returns_Correct_When_ParamIsValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetCountry_Returns_Correct_When_ParamIsValid));

            var country = new Country { Id = Guid.NewGuid(), Name= "Bulgaria"};
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
                var result = await sut.GetCountry(country.Name);

                Assert.AreEqual("Bulgaria", result.Name);
                Assert.IsInstanceOfType(result, typeof(CountryDTO));
            }
        }

        [TestMethod]
        public async Task GetCountry_Throws_When_NameNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetCountry_Throws_When_NameNotFound));

            var country = new Country { Id = Guid.NewGuid(), Name = "Bulgaria", IsDeleted = true };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Countries.AddAsync(country);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetCountry("Japan"));
            }
        }
    }
}
