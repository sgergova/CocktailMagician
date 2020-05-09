using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagicianDataBase.Entities
{
    public class Cocktail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Bar> Bars { get; set; }
        public string ImageURL { get; set; }

    }
}
