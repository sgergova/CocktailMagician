using CocktailMagician.DataBase.AppContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
