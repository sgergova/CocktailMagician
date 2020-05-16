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

namespace CocktailMagician.Tests.BarServicesTests
{
    [TestClass]
    public class CreateBar_Should
    {
        [TestMethod]
        public async Task CreateBar_Return_Correct_When_Params_AreValid()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(CreateBar_Return_Correct_When_Params_AreValid));

            var bar = new BarDTO
            {
                Id = Guid.NewGuid(),
                Name = "Cosmos"
            };

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = await sut.CreateBar(bar);
                Assert.AreEqual(1, assertContext.Bars.Count());
                Assert.AreEqual(bar.Name, result.Name);
                Assert.IsInstanceOfType(result, typeof(BarDTO));
            }
        }

        [TestMethod]
        public async Task CreateBar_Throws_When_Name_Exists()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(CreateBar_Throws_When_Name_Exists));

            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Cosmos"
            };

            var barDTO = new BarDTO
            {
                Id = Guid.NewGuid(),
                Name = "Cosmos"
            };

            using (var arranegContext = new CMContext(options))
            {
                await arranegContext.Bars.AddAsync(bar);
                await arranegContext.SaveChangesAsync();
            }

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateBar(barDTO));
            }
        }

        [TestMethod]
        public async Task CreateBar_Throws_When_NameIsNull()
        {
            //Arrange

            var options = Utils.GetOptions(nameof(CreateBar_Throws_When_NameIsNull));

            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Cosmos"
            };

            var barDTO = new BarDTO
            {
                Id = Guid.NewGuid(),
                Name = null
            };

            using (var arranegContext = new CMContext(options))
            {
                await arranegContext.Bars.AddAsync(bar);
                await arranegContext.SaveChangesAsync();
            }

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateBar(barDTO));
            }
        }
    }
}
