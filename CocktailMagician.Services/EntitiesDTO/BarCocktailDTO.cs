using CocktailMagician.Data.Abstract;
using CocktailMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.EntitiesDTO
{
    public class BarCocktailDTO :EntitiesDetails
    {
        public Guid Id { get; set; }
        public Guid BarId { get; set; }
        public Bar Bar { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public bool IsListed { get; set; }
        public DateTime ListedOn { get; set; }
        public DateTime UnlistedOn { get; set; }

    }
}
