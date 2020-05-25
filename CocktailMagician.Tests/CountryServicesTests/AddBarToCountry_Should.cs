using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CountryServicesTests
{
    [TestClass]
   public class AddBarToCountry_Should
    {

        [TestMethod]
        public async Task AddBarToCountry_ShouldAdd_Correct_WhenParams_AreValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddBarToCountry_ShouldAdd_Correct_WhenParams_AreValid));
            var country = new Country { Id = Guid.NewGuid(), Name = "England" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Cosmos" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Countries.AddAsync(country);
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);
                var result = await sut.AddBarToCountry(country.Id, bar.Id);

                Assert.AreEqual(1, result.Bars.Count);
                Assert.IsInstanceOfType(result, typeof(CountryDTO));
            }
        }
        [TestMethod]
        public async Task AddBarToCountry_Thrwos_When_CountryNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddBarToCountry_Thrwos_When_CountryNotFound));
            var id = Guid.NewGuid();
            var country = new Country { Id = Guid.NewGuid(), Name = "England" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Cosmos" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Countries.AddAsync(country);
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.AddBarToCountry(id, bar.Id));
            }
        }

        [TestMethod]
        public async Task AddBarToCountry_Thrwos_When_BarNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddBarToCountry_Thrwos_When_CountryNotFound));
            var id = Guid.NewGuid();
            var country = new Country { Id = Guid.NewGuid(), Name = "England" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Cosmos" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Countries.AddAsync(country);
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.AddBarToCountry(bar.Id, id));
            }
        }

        [TestMethod]
        public async Task AddBarToCountry_Thrwos_When_BarIsAlreadyAtTheCountry()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddBarToCountry_Thrwos_When_BarIsAlreadyAtTheCountry));
            var country = new Country { Id = Guid.NewGuid(), Name = "England" };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Cosmos", CountryId = country.Id };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Countries.AddAsync(country);
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);

                await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => sut.AddBarToCountry(country.Id, bar.Id));
            }
        }
    }
}
