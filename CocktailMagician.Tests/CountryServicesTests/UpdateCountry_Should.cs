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
   public class UpdateCountry_Should
    {
        [TestMethod]
        public async Task UpdateCountry_UpdatesCorrect_When_Params_AreValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(UpdateCountry_UpdatesCorrect_When_Params_AreValid));

            var country = new Country { Id = Guid.NewGuid(), Name = "Bulgariaaa" };
            var countryDTO = new CountryDTO { Name = "Bulgaria" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Countries.AddAsync(country);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);
                var result = await sut.UpdateCountry(country.Id, countryDTO);

                Assert.AreEqual("Bulgaria", result.Name);
                Assert.IsInstanceOfType(result, typeof(CountryDTO));
            }
        }
        [TestMethod]
        public async Task UpdateCountry_Throws_When_CountryNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(UpdateCountry_Throws_When_CountryNotFound));

            var id = Guid.NewGuid();
            var countryDTO = new CountryDTO { Name = "Bulgaria" };


            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.UpdateCountry(id, countryDTO));
            }
        }
    }
}
