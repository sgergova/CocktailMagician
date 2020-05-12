using CocktailMagician.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CocktailMagician.Data.Entities
{
   public class CocktailIngredient : EntitiesDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
