using CocktailMagician.Data.Entities;
using System;
using System.Collections.Generic;

namespace CocktailMagician.Services.EntitiesDTO
{
    public class IngredientDTO 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CocktailIngredient> CocktailIngredients { get; set; }
        public int Quantity { get; set; }
        public int Rating { get; set; }
        public bool IsAlcoholic { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
