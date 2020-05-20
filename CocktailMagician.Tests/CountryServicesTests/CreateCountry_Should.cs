using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CountryServicesTests
{
    [TestClass]
   public class CreateCountry_Should
    {
        [TestMethod]
        public async Task CreateCountry_Creates_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateCountry_Creates_Correct));

            var countryDTO = new CountryDTO { Name = "Japan" };

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);
                var result = await sut.CreateCountry(countryDTO);

                Assert.AreEqual(1, assertContext.Countries.Count());
                Assert.AreEqual("Japan", result.Name);
                Assert.IsInstanceOfType(result, typeof(CountryDTO));
            }
        }
        [TestMethod]
        public async Task CreateCountry_Throws_When_NameExists()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateCountry_Throws_When_NameExists));

            var country = new Country { Id = Guid.NewGuid(), Name = "Bulgaria" };
            var countryDTO = new CountryDTO { Name = "Bulgaria" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.AddAsync(country);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);

                await Assert.ThrowsExceptionAsync<InvalidOperationException>(()
                    => sut.CreateCountry(countryDTO));
            }
        }
        //TODO null or whitespace
        [TestMethod]
        public async Task CreateCountry_Throw_When_NameIsNull()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateCountry_Throw_When_NameIsNull));

            var country = new Country { Id = Guid.NewGuid(), Name = "Bulgaria" };
            var countryDTO = new CountryDTO { Name = null };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.AddAsync(country);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(()
                    => sut.CreateCountry(countryDTO));
            }
        }
    }
}
//public async Task<CountryDTO> CreateCountry(CountryDTO countryDTO)
//{
//    if (this.context.Countries.Any(c => c.Name == countryDTO.Name))
//        throw new InvalidOperationException("The name of the country must be unique!");

//    if (countryDTO.Name == null)
//        throw new ArgumentNullException("The name of the country is mandatory!");

//    var country = new Country
//    {
//        Name = countryDTO.Name,
//        Bars = countryDTO.Bars.GetEntities(),
//        CreatedOn = DateTime.UtcNow,
//    };

//    await this.context.Countries.AddAsync(country);
//    await this.context.SaveChangesAsync();

//    return country.GetDTO();

//}