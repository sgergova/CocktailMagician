using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Entities
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Cocktail> Cocktails { get; set; }
        public int Quantity { get; set; }
        public int Rating { get; set; }
    }
}
