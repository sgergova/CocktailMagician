using CocktailMagician.DataBase.AppContext;
using Microsoft.EntityFrameworkCore;

namespace CocktailMagician.Tests
{
	public class Utils
    {
		public static DbContextOptions<CMContext> GetOptions(string database)
		{
			return new DbContextOptionsBuilder<CMContext>()
						.UseInMemoryDatabase(database)
						.Options;


		}
	}
}
