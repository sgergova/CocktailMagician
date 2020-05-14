using CocktailMagician.Data.Abstract;
using CocktailMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.EntitiesDTO
{
    public class BarDTO :EntitiesDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public ICollection<BarCocktail> BarCocktails { get; set; }
        public ICollection<BarStar> Stars { get; set; }
        public ICollection<BarComment> Comments { get; set; }
        public string ImageURL { get; set; }
    }
}
