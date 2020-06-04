using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.UserServicesTests
{
    [TestClass]
  public  class UserServices_Should
    {
        [TestMethod]
        public async Task UpdateUser_Updates_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(UpdateUser_Throws_WhenNoUser_Found));

            var user = new User { Id = Guid.NewGuid(), UserName = "Kalina"};

            var userDTO = new UserDTO 
            {
                UserName = "Kalina",
                PhoneNumber = "0888888888",
                Email = "kalina@abv.bg"
            };

            using (var arrangeContext = new CMContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new UserServices(assertContext);
                var result = await sut.UpdateUser(userDTO);

                Assert.AreEqual("0888888888", result.PhoneNumber);
                Assert.AreEqual("kalina@abv.bg", result.Email);
                Assert.AreEqual(user.Id, result.Id);
                Assert.IsInstanceOfType(result, typeof(UserDTO));

            }
        }

        [TestMethod]
        public async Task UpdateUser_Throws_WhenNoUser_Found()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(UpdateUser_Throws_WhenNoUser_Found));

            var userDTO = new UserDTO { Id = Guid.NewGuid(), UserName = "Marina", };

            //Act, Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new UserServices(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.UpdateUser(userDTO));
            }
        }
    }
}
