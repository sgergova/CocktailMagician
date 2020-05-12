using CocktailMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.EntitiesDTO
{
   public class IngredientDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CocktailIngredient> CocktailIngredients { get; set; }
        public int Quantity { get; set; }
        public int Rating { get; set; }
    }
}
