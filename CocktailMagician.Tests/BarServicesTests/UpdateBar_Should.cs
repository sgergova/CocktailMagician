using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
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
   public class UpdateBar_Should
    {
        [TestMethod]
        public async Task UpdateBar_Updates_Correct_When_Params_AreValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(UpdateBar_Updates_Correct_When_Params_AreValid));

            var bar = new Bar
            {
                Id = Guid.Parse("b0d1870e-5025-41b2-a54d-8706fc6c72c6"),
                Name = "Cosmos",
                Address = "Sofia",
                Country = new Country
                {
                    Id = Guid.Parse("4e564599-bb62-40e4-969c-31344692c45a"),
                    Name = "Bulgaria",
                }
            };

            var barDTO = new BarDTO
            {
                Name = "Dante",
                Address = "Sofia, Suborna Str.",
                Phone = "08888 888 888" ,
                CountryId = bar.CountryId,
                CountryName = bar.Country.Name
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
                var result = await sut.UpdateBar(bar.Id, barDTO);

                Assert.AreEqual("Dante", result.Name);
                Assert.AreEqual("Sofia, Suborna Str.", result.Address);
                Assert.AreEqual("08888 888 888", result.Phone);

            }

        }

        [TestMethod]
        public async Task UpdateBar_Returns_Correct_Instance()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(UpdateBar_Returns_Correct_Instance));

            var bar = new Bar
            {
                Id = Guid.Parse("b30e0c1c-3ad0-43fc-aeae-e7387c9d2300"),
                Name = "Cosmos",
                Address = "Sofia",
                Country = new Country
                {
                    Id = Guid.Parse("8f7b2582-c6c9-4b2f-95a4-e4749cd8f53d"),
                    Name = "Bulgaria",
                }
            };

            var barDTO = new BarDTO
            {
                Name = "Dante",
                Address = "Sofia, Suborna Str.",
                Phone = "08888 888 888",
                CountryId = bar.CountryId,
                CountryName = bar.Country.Name
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
                var result = await sut.UpdateBar(bar.Id, barDTO);

                Assert.IsInstanceOfType(result, typeof(BarDTO));
            }

        }
    }
}
//public async Task<BarDTO> UpdateBar(Guid id, BarDTO barDTO)
//{
//    var barToUpdate = await this.context.Bars
//                                        .Include(b => b.Country)
//                                        .Where(b => b.IsDeleted == false)
//                                        .FirstOrDefaultAsync(b => b.Id == id);

//    barToUpdate.Name = barDTO.Name;
//    barToUpdate.Address = barDTO.Address;
//    barToUpdate.Phone = barDTO.Phone;
//    barToUpdate.BarImageURL = barDTO.ImageURL;
//    barToUpdate.Country.Name = barDTO.CountryName;
//    barToUpdate.ModifiedOn = DateTime.UtcNow;

//    this.context.Bars.Update(barToUpdate);
//    await this.context.SaveChangesAsync();

//    return barToUpdate.GetDTO();

//}