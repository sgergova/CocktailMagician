using CocktailMagician.Data.Abstract;
using CocktailMagician.Data.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CocktailMagician.Data.Entities
{
    public class Cocktail :EntitiesDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The cocktail's name cannot be more than 30 characters.")]
        public string Name { get; set; }
        public double Rating { get; set; }
        public double AlcoholPercentage { get; set; }
        public ICollection<CocktailIngredient> CocktailIngredients { get; set; }
        public ICollection<BarCocktail> Bars { get; set; }
        public ICollection<CocktailComment> Comments { get; set; }
        public ICollection<CocktailStar> Stars { get; set; }
        public bool IsAlcoholic { get; set;  }
        public string ImageURL { get; set; }
       

    }
}
