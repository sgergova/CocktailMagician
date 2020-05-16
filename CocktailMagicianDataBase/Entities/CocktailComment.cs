using System;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Data.Entities
{
    public class CocktailComment 
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The comment cannot be more than 500 characters.")]
        public string Comments { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
