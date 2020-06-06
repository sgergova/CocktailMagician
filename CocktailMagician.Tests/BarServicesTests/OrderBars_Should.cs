using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
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
    public class OrderBars_Should
    {
        [TestMethod]
        public void OrderBars_Orders_ByName_Ascending()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(OrderBars_Orders_ByName_Ascending));
            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Manhattan",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "USA"
                }
            };

            var bar2 = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "The Cocktail Bar",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Belguim"
                }
            };
            var bars = new List<Bar>() { bar, bar2 }.AsQueryable();

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.AddRangeAsync(bar, bar2);
                arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = sut.OrderBar(bars, "name");

                Assert.AreEqual(result.ToList()[0].Name, bar.Name);
                Assert.AreEqual(result.ToList()[0].Id, bar.Id);
                Assert.AreEqual(result.ToList()[1].Name, bar2.Name);
                Assert.AreEqual(result.ToList()[1].Id, bar2.Id);
                Assert.IsInstanceOfType(result, typeof(ICollection<BarDTO>));
            }
        }

        [TestMethod]
        public void OrderBars_Orders_ByName_Descending()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(OrderBars_Orders_ByName_Descending));
            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Manhattan",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "USA"
                }
            };

            var bar2 = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "The Cocktail Bar",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Belguim"
                }
            };
            var bars = new List<Bar>() { bar, bar2 }.AsQueryable();

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.AddRangeAsync(bar, bar2);
                arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = sut.OrderBar(bars, "name_desc").ToList();

                Assert.AreEqual(result[0].Name, bar2.Name);
                Assert.AreEqual(result[0].Id, bar2.Id);
                Assert.AreEqual(result[1].Name, bar.Name);
                Assert.AreEqual(result[1].Id, bar.Id);
                Assert.IsInstanceOfType(result, typeof(ICollection<BarDTO>));
            }
        }
        [TestMethod]
        public void OrderBars_Orders_ByAddress()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(OrderBars_Orders_ByAddress));
            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Manhattan",
                Address = "American 13, Str",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "USA"
                }
            };

            var bar2 = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "The Cocktail Bar",
                Address = "Belgium 12, Str",
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Belguim"
                }
            };
            var bars = new List<Bar>() { bar, bar2 }.AsQueryable();
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.AddRangeAsync(bar, bar2);
                arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);
                var result = sut.OrderBar(bars, "address").ToList();

                Assert.AreEqual(result[0].Address, bar.Address);
                Assert.AreEqual(result[0].Id, bar.Id);
                Assert.AreEqual(result[1].Address, bar2.Address);
                Assert.AreEqual(result[1].Id, bar2.Id);
            }
        }
    }
}

