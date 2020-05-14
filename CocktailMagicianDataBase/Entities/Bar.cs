using CocktailMagician.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocktailMagician.Data.Entities
{
    public class Bar : EntitiesDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public ICollection<BarCocktail> BarCocktails { get; set; } = new List<BarCocktail>();
        public ICollection<BarStar> Stars { get; set; } = new List<BarStar>();
        public ICollection<BarComment> Comments { get; set; } = new List<BarComment>();
        public string ImageURL { get; set; }
       
        // set google maps
    }
}
