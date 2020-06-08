using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarServicesTests
{
    [TestClass]
    public class DeleteBar_Should
    {
        [TestMethod]
        public async Task DeleteBar_Should_Delete_Correct()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(DeleteBar_Should_Delete_Correct));

            var country = new Country { Id = Guid.NewGuid(), Name = "Bulagria", };
            var bar = new Bar { Id = Guid.NewGuid(), Name = "Cosmos", CountryId = country.Id };
         

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Countries.AddAsync(country);
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = await sut.DeleteBar(bar.Id);

                Assert.AreEqual(true, result.IsDeleted);
            }
        }
        [TestMethod]
        public async Task DeleteBar_Throws_When_BarNotFound()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(DeleteBar_Throws_When_BarNotFound));

            var id = Guid.NewGuid();


            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteBar(id));
            }
        }
    }
}
