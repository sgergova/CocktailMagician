using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.BarCommentsServicesTests
{
    [TestClass]
   public class GetAllCommentsOfUser_Should
    {
        [TestMethod]
        public async Task GetAllCommentsOfUser_ShouldReturn_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsOfUser_ShouldReturn_Correct));
            
            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };

            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var bar2 = new Bar { Id = Guid.NewGuid(), Name = "Cosmos" };
            var comment = new BarComment { BarId = bar.Id, UserId =user.Id };
            var comment2 = new BarComment { BarId = bar2.Id, UserId = user.Id, IsDeleted = true };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddRangeAsync(bar, bar2);
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.BarComments.AddAsync(comment);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);
                var result = await sut.GetAllCommentsOfUser(null, user.UserName);

                Assert.AreEqual(1, result.Count);
                Assert.IsInstanceOfType(result, typeof(ICollection<BarCommentDTO>));
            }
        }
    }
}
