using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
   public class BarRatingServices
    {
        private readonly CMContext context;

        public BarRatingServices(CMContext context)
        {
            this.context = context;
        }

    }
}
