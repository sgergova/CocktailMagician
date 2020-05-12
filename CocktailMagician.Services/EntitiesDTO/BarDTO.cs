using CocktailMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.EntitiesDTO
{
    public class BarDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public ICollection<BarCocktail> Cocktails { get; set; }
        public ICollection<Star> Stars { get; set; }
        public ICollection<BarComment> Comments { get; set; }
        public string ImageURL { get; set; }
    }
}
