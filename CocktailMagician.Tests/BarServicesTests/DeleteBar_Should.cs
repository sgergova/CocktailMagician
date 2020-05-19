using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
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
        public async Task DeleteBar_Throws_When_BarNotFound()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(DeleteBar_Throws_When_BarNotFound));

            var id = Guid.Parse("acce59ad-4010-449a-9a1c-2b8021c3deff");


            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(()=>sut.DeleteBar(id));
            }
        }

        [TestMethod]
        public async Task DeleteBar_Should_Delete_Correct()
        {
            //Arrange 
            var options = Utils.GetOptions(nameof(DeleteBar_Should_Delete_Correct));

            var country = new Country
            {
                Id = Guid.Parse("1fc5a0a8-5bf3-4dcd-bd17-64ee24933c73"),
                Name = "Bulagria",
            };
            var bar = new Bar
            {
                Id = Guid.Parse("0377d7f6-f14b-4e46-8617-c153f20a58f3"),
                Name = "Cosmos",
                CountryId = country.Id
            };

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
                var result = sut.DeleteBar(bar.Id);

                Assert.AreEqual(true, result.Result);
                Assert.AreEqual(0, assertContext.Bars.Count());
            }
        }
    }
}
//public async Task<BarDTO> DeleteBar(Guid id)
//{
//    var barToDelete = await GetAllBarsQueryable()
//                           .Include(b => b.Country)
//                           .FirstOrDefaultAsync(b => b.Id == id)
//                           ?? throw new ArgumentNullException();

//    var barCocktails = AvailabilityAtBar(barToDelete.Id).Result.GetEntities();

//    barToDelete.IsDeleted = true;
//    barToDelete.DeletedOn = DateTime.UtcNow;

//    if (barCocktails.Count != 0)
//    {
//        foreach (var barCocktail in barCocktails)
//        {
//            barToDelete.BarCocktails.Remove(barCocktail);
//        }
//    }


//    context.Bars.Update(barToDelete);
//    await context.SaveChangesAsync();


//    return barToDelete.GetDTO();
//}