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
   public class RemoveBarFromCountry_Should
    {

        [TestMethod]
        public async Task RemoveBarFromCountry_ShouldRemove_Correct_WhenParams_AreValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(RemoveBarFromCountry_ShouldRemove_Correct_WhenParams_AreValid));
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
                var result = await sut.RemoveBarFromCountry(country.Id, bar.Id);

                Assert.AreEqual(0, result.Bars.Count);
                Assert.IsInstanceOfType(result, typeof(CountryDTO));
            }
        }
        [TestMethod]
        public async Task RemoveBarFromCountry_Thrwos_When_CountryNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(RemoveBarFromCountry_Thrwos_When_CountryNotFound));
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

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.RemoveBarFromCountry(id, bar.Id));
            }
        }

        [TestMethod]
        public async Task RemoveBarFromCountry_Thrwos_When_BarNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(RemoveBarFromCountry_Thrwos_When_BarNotFound));
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

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.RemoveBarFromCountry(bar.Id, id));
            }
        }

        [TestMethod]
        public async Task RemoveBraFromCountry_Thrwos_When_BarIsAlreadyAtTheCountry()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(RemoveBraFromCountry_Thrwos_When_BarIsAlreadyAtTheCountry));
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

                await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => sut.RemoveBarFromCountry(country.Id, bar.Id));
            }
        }
    }
}

