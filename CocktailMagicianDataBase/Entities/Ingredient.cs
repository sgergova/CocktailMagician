using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagicianDataBase.Entities
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Cocktail> Cocktails { get; set; }
        public int Quantity { get; set; }
        public int Rating { get; set; }
        public string ImageURL { get; set; }
    }
}
