using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CocktailMagician.Data.Entities
{
    public class Cocktail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public double AlcoholPercentage { get; set; }
        public ICollection<CocktailIngredient> Ingredients { get; set; }
        public ICollection<BarCocktail> Bars { get; set; }
        public ICollection<Star> Stars { get; set; }
        public ICollection<CocktailComment> Comments { get; set; }
        public string ImageURL { get; set; }

    }
}
