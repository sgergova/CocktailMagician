using CocktailMagician.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailMagician.Data.Entities
{
    public class CocktailComment : EntitiesDetails
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The comment cannot be more than 500 characters.")]
        public string Comments { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
    }
}
