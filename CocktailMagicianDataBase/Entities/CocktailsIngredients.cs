using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Entities
{
   public  class CocktailsIngredients
    {
        public Guid Id { get; set; }
        public Guid CocktailId { get; set; }
        public Guid IngredientId { get; set; }

    }
}
