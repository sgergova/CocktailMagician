using CocktailMagician.Data.Entities;
using System;

namespace CocktailMagician.Services.EntitiesDTO
{
    public class CocktailIngredientDTO
    {
        public Guid Id { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
