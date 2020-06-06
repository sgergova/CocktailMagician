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

namespace CocktailMagician.Tests.BarCommentsServicesTests
{
    [TestClass]
    public class GetAllCommentsOfBar_Should
    {

        [TestMethod]
        public async Task GetAllCommentsOfBar_Returns_Correct_WhenParam_IsValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsOfBar_Returns_Correct_WhenParam_IsValid));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var user2 = new User { Id = Guid.NewGuid(), UserName = "Petur" };

            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var barComment = new BarComment { BarId = bar.Id, UserId = user.Id };
            var barComment2 = new BarComment { BarId = bar.Id, UserId = user2.Id };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Users.AddRangeAsync(user, user2);
                await arrangeContext.BarComments.AddRangeAsync(barComment, barComment2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);
                var result = await sut.GetAllCommentsOfBar(bar.Id);

                Assert.AreEqual(2, result.Count());
                Assert.IsInstanceOfType(result, typeof(ICollection<BarCommentDTO>));
            }
        }


        [TestMethod]
        public async Task GetAllCommentsOfBar_Returns_OnlyExistingEntities()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsOfBar_Returns_OnlyExistingEntities));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var user2 = new User { Id = Guid.NewGuid(), UserName = "Petur" };

            var bar = new Bar { Id = Guid.NewGuid(), Name = "Manhattan" };
            var barComment = new BarComment { BarId = bar.Id, UserId = user.Id };
            var barComment2 = new BarComment { BarId = bar.Id, UserId = user2.Id, IsDeleted = true };


            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Bars.AddAsync(bar);
                await arrangeContext.Users.AddRangeAsync(user, user2);
                await arrangeContext.BarComments.AddRangeAsync(barComment, barComment2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarCommentsServices(assertContext);
                var result = await sut.GetAllCommentsOfBar(bar.Id);

                Assert.AreEqual(1, result.Count());
                Assert.IsInstanceOfType(result, typeof(ICollection<BarCommentDTO>));
            }
        }
    }
}
