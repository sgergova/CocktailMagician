﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocktailMagician.Data.Entities
{
    public class Ingredient 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "The name should be at least 3 characters")]
        [StringLength(40, ErrorMessage = "The ingredient's name cannot be more than 40 characters")]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "The ingredient's description cannot be more than 300 characters")]
        public string Description { get; set; }
        public ICollection<CocktailIngredient> CocktailIngredients { get; set; } = new List<CocktailIngredient>();
        public int Quantity { get; set; }
        public int Rating { get; set; }
        public bool IsAlcoholic { get; set; }
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
