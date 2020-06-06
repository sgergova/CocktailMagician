using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarServicesTests
{
    [TestClass]
    public class AddCocktailsToBar_Should
    {

        //[TestMethod]
        //public async Task AddCocktailsToBar_Adds_Correct()
        //{
        //    //Arrange
        //    var options = Utils.GetOptions(nameof(AddCocktailsToBar_Adds_Correct));

        //    var country = new Country { Id = Guid.NewGuid(), Name = "Bulgaria" };
        //    var bar = new Bar
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Cosmos",
        //        Country = country,
        //    };
        //    var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
        //    var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "Cosmopolitan" };
        //    var cocktailNames = new List<string> { "Manhattan", "Cosmopolitan" };

        //    using (var arrangeContext = new CMContext(options))
        //    {
        //        await arrangeContext.Bars.AddAsync(bar);
        //        await arrangeContext.Countries.AddAsync(country);
        //        await arrangeContext.Cocktails.AddRangeAsync(cocktail, cocktail2);
        //        await arrangeContext.SaveChangesAsync();
        //    }
        //    //Act, Assert 
        //    using (var assertContext = new CMContext(options))
        //    {
        //        var sut = new BarServices(assertContext);
        //        var result = await sut.AddCocktailsToBar(bar.Name, cocktailNames);

        //        Assert.AreEqual(2, result.BarCocktails.Count);
        //    }
        //}
        [TestMethod]
        public async Task AddCocktailsToBar_Throws_When_NoBarFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(AddCocktailsToBar_Throws_When_NoBarFound));

            var bar = new Bar
            {
                Id = Guid.NewGuid(),
                Name = "Cosmos",
                Address = "Sofia",
                Rating = 2,
                Country = new Country { Name = "Bulgaria" }
            };
            var barName = "Rabbit Hole";
            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "Cosmopolitan" };
            var cocktailNames = new List<string> { "Manhattan", "Cosmopolitan" };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Cocktails.AddRangeAsync(cocktail, cocktail2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act, Assert 
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.AddCocktailsToBar(barName, cocktailNames));
            }
        }
    }
}
//public async Task<BarDTO> AddCocktailsToBar(string barName, ICollection<string> cocktailNames)
//{
//    var bar = await this.context.Bars
//                                .FirstOrDefaultAsync(c => c.Name == barName && c.IsDeleted == false);

//    if (bar == null)
//        throw new ArgumentNullException(Exceptions.EntityNotFound);

//    var a = cocktailNames.Select(async cN => { await Helper(barName, cN, bar.Id); });

//    await this.context.Cocktails.AddRangeAsync();
//    await this.context.SaveChangesAsync();

//    return bar.GetDTO();
//}

