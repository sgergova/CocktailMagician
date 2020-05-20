using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocktailMagician.Data.Entities
{
    public class Cocktail 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "The name should be at least 3 characters")]
        [StringLength(30, ErrorMessage = "The cocktail's name cannot be more than 30 characters.")]
        public string Name { get; set; }
        public double Rating { get; set; }
        public double AlcoholPercentage { get; set; }
        public ICollection<CocktailIngredient> CocktailIngredients { get; set; } = new List<CocktailIngredient>();
        public ICollection<BarCocktail> Bars { get; set; } = new List<BarCocktail>();
        public ICollection<CocktailComment> Comments { get; set; } = new List<CocktailComment>();
        public ICollection<CocktailRating> Stars { get; set; } = new List<CocktailRating>();
        public bool IsAlcoholic { get; set;  }
        [Url]
        public string ImageURL { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }


    }
}
