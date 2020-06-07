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

namespace CocktailMagician.Tests.CocktailsServicesTests
{
    [TestClass]
   public  class GetIndexPageCocktails_Should
    {
        [TestMethod]
		public async Task GetIndexPageCocktails_Retuns_Correct_When_ParamsAreValid()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageCocktails_Retuns_Correct_When_ParamsAreValid));
			
			var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan", };
			var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "The Mall Coffee" };


			using (var arrangeContext = new CMContext(options))
			{
				await arrangeContext.Cocktails.AddRangeAsync(cocktail, cocktail2);
				await arrangeContext.SaveChangesAsync();
			};


			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new CocktailServices(assertContext);
				var result = await sut.GetIndexPageCocktails(1, "Ma");

				Assert.AreEqual(2, result.Count);
				Assert.AreEqual(cocktail.Id, result.ToList()[0].Id);
				Assert.AreEqual(cocktail.Name, result.ToList()[0].Name);
				Assert.AreEqual(cocktail2.Id, result.ToList()[1].Id);
				Assert.AreEqual(cocktail2.Name, result.ToList()[1].Name);
				Assert.IsInstanceOfType(result, typeof(ICollection<CocktailDTO>));
			}
		}

		[TestMethod]
		public async Task GetIndexPageCocktails_ShouldReturn_Correct_When_NoParams_ArePassed()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageCocktails_ShouldReturn_Correct_When_NoParams_ArePassed));
			
			var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan", };
			var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "The Mall Coffee" };


			using (var arrangeContext = new CMContext(options))
			{
				await arrangeContext.Cocktails.AddRangeAsync(cocktail, cocktail2);
				await arrangeContext.SaveChangesAsync();
			};

			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new CocktailServices(assertContext);
				var result = await sut.GetIndexPageCocktails(1, null);

				Assert.AreEqual(2, result.Count);
			}
		}
		[TestMethod]
		public async Task GetIndexPageCocktails_ShouldReturn_Correct_When_Name_IsPassed()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageCocktails_ShouldReturn_Correct_When_Name_IsPassed));
			
			var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan", };
			var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "The Mall Coffee" };


			using (var arrangeContext = new CMContext(options))
			{
				await arrangeContext.Cocktails.AddRangeAsync(cocktail, cocktail2);
				await arrangeContext.SaveChangesAsync();
			};
			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new CocktailServices(assertContext);
				var result = await sut.GetIndexPageCocktails(1, "Manhattan");

				Assert.AreEqual(1, result.Count);
				Assert.AreEqual(cocktail.Id, result.ToList()[0].Id);
				Assert.AreEqual(cocktail.Name, result.ToList()[0].Name);

			}
		}
		
		
		[TestMethod]
		public async Task GetIndexPageCocktails_Returns_Only_ExistingInstances()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageCocktails_Returns_Only_ExistingInstances));
			var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan", IsDeleted = true };
			var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "The Mall Coffee" };


			using (var arrangeContext = new CMContext(options))
			{
				await arrangeContext.Cocktails.AddRangeAsync(cocktail, cocktail2);
				await arrangeContext.SaveChangesAsync();
			};
			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new CocktailServices(assertContext);
				var result = await sut.GetIndexPageCocktails(0, null);

				Assert.AreEqual(1, result.Count);
				Assert.AreEqual(cocktail2.Id, result.ToList()[0].Id);
				Assert.AreEqual(cocktail2.Name, result.ToList()[0].Name);
			}
		}

		[TestMethod]
		public async Task GetIndexPageCocktails_Returns_Correct_WhenMoreThanOne_EntityFound()
		{
			//Arrange
			var options = Utils.GetOptions(nameof(GetIndexPageCocktails_Returns_Correct_WhenMoreThanOne_EntityFound));
			
			var cocktail = new Cocktail { Id = Guid.NewGuid(), Name = "Manhattan" };
			var cocktail2 = new Cocktail { Id = Guid.NewGuid(), Name = "The Mall Coffee" };
			

			using (var arrangeContext = new CMContext(options))
			{
				await arrangeContext.Cocktails.AddRangeAsync(cocktail, cocktail2);
				await arrangeContext.SaveChangesAsync();
			};

			//Act,Assert
			using (var assertContext = new CMContext(options))
			{
				var sut = new CocktailServices(assertContext);
				var result = await sut.GetIndexPageCocktails(0, "Ma");

				Assert.AreEqual(2, result.Count);
				Assert.AreEqual(cocktail.Id, result.ToList()[0].Id);
				Assert.AreEqual(cocktail.Name, result.ToList()[0].Name);
				Assert.AreEqual(cocktail2.Id, result.ToList()[1].Id);
				Assert.AreEqual(cocktail2.Name, result.ToList()[1].Name);

				Assert.IsInstanceOfType(result, typeof(ICollection<CocktailDTO>));
			}
		}
	}
}
//ICollection<CocktailDTO>
//IQueryable<Cocktail> cocktails = this.context.Cocktails
//								   .Include(b => b.Comments)
//									   .ThenInclude(c => c.User)
//								   .Where(b => b.IsDeleted == false);
//            if (searchCriteria != null)
//                cocktails = cocktails.Where(b => b.Name.Contains(searchCriteria));

//            cocktails = cocktails.OrderBy(c => c.Name);
//            cocktails = currentPage == 1 ? cocktails.Take(10) : cocktails.Skip((currentPage - 1) * 10).Take(10);

//var results = await cocktails.ToListAsync();
//            return results.GetDTOs();