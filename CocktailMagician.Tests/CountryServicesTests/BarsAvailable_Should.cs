using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CountryServicesTests
{
    [TestClass]
   public class BarsAvailable_Should
    {
        [TestMethod]
        public async Task BarsAvailable_Returns_OnlyExisting_Entities()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(BarsAvailable_Returns_OnlyExisting_Entities));
            var country = new Country { Id = Guid.NewGuid(), Name = "Bulgaria" };

            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Manhattan",
                CountryId = country.Id,
                Country = country
            };

            var bar2 = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "The Cocktail Bar",
                Rating = 1,
                IsDeleted = true,
                Country = country,
                CountryId = country.Id,
            };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.AddRangeAsync(bar, bar2);
                await arrangeContext.AddAsync(country);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CountryServices(assertContext);
                var result = await sut.BarsAvailable(country.Id);

                Assert.AreEqual(1, result.Count);
                Assert.IsInstanceOfType(result, typeof(ICollection<BarDTO>));
            }
        }
    }
}
