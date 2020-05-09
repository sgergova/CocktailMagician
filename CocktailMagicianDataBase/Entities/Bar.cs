using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagicianDataBase.Entities
{
    public class Bar
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        public int Rating { get; set; }
        public List<Cocktail> Cocktails { get; set; }
        public string ImageURL { get; set; }


    }
}
