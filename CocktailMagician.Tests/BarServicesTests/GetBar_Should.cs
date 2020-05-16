using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarServicesTests
{
    [TestClass]
    public class GetBar_Should
    {
        [TestMethod]
        public async Task GetBar_Returns_Correct_When_Params_Are_Valid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetBar_Returns_Correct_When_Params_Are_Valid));

            var bar = new Bar
            {
                Id = Guid.Parse("cda3e6b5-c77c-4682-a7ff-73987919a059"),
                Name = "Cosmos",
                Address = "Sofia",
                Rating = 2,

            };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert

            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = await sut.GetBar(bar.Id);

                Assert.AreEqual(result.Name, bar.Name);
                Assert.AreEqual(result.Address, bar.Address);
                Assert.AreEqual(result.Rating, bar.Rating);
                Assert.IsInstanceOfType(result, typeof(BarDTO));
            }
        }

        [TestMethod]
        public async Task GetBar_Throws_When_IdIsNull()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetBar_Throws_When_IdIsNull));

            var bar = new Bar
            {
                Id = Guid.Parse("cda3e6b5-c77c-4682-a7ff-73987919a059"),
                Name = "Cosmos",
                Address = "Sofia",
                Rating = 2,

            };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert

            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetBar(null));
            }
        }
    }
}
