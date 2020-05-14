using CocktailMagician.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CocktailMagician.Data.Entities
{
    public class Ingredient :EntitiesDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "The ingredient's name cannot be more than 40 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The ingredient's description cannot be more than 100 characters")]
        public string Description { get; set; }
        public ICollection<CocktailIngredient> CocktailIngredients { get; set; }
        public int Quantity { get; set; }
        
        public int Rating { get; set; }
        public bool IsAlcoholic { get; set; }
    }
}
