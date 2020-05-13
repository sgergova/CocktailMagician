using CocktailMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.EntitiesDTO
{
    public class CocktailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public double AlcoholPercentage { get; set; }
        public ICollection<CocktailIngredient> Ingredients { get; set; }
        public ICollection<BarCocktail> Bars { get; set; }
        public ICollection<BarStar> Stars { get; set; }
        public ICollection<CocktailComment> Comments { get; set; }
        public bool IsAlcoholic { get; set; }
        public string ImageURL { get; set; }
    }
}
