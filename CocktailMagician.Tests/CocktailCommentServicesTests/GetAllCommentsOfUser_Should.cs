using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailCommentServicesTests
{
    [TestClass]
 public   class GetAllCocktailCommentsOfUser_Should
    {
        [TestMethod]
        public async Task GetAllCommentsOfUser_ShouldReturn_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCommentsOfUser_ShouldReturn_Correct));

            var user = new User { Id = Guid.NewGuid(), UserName = "Ivan" };

            var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
            var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "Cosmos" };
            var comment = new CocktailComment { CocktailId = cocktail.Id, UserId = user.Id };
            var comment2 = new CocktailComment { CocktailId = cocktail2.Id, UserId = user.Id, IsDeleted = true };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Cocktails.AddRangeAsync(cocktail, cocktail2);
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.CocktailComments.AddRangeAsync(comment, comment2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                //TODO: Replace USername with id
                var sut = new CocktailCommentServices(assertContext);
                var result = await sut.GetAllCommentsOfUser(user.Id, user.UserName);

                Assert.AreEqual(1, result.Count);
                Assert.IsInstanceOfType(result, typeof(ICollection<CocktailCommentsDTO>));
            }
        }
    }
}
//public async Task<ICollection<CocktailCommentsDTO>> GetAllCommentsOfUser(Guid? id, string username)
//{
//    var comments = await this.context.CocktailComments
//                             .Where(cc => cc.IsDeleted == false && cc.UserId == id || cc.User.UserName == username)
//                             .ToListAsync()
//                              ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

//    return comments.GetDTOs();
//}