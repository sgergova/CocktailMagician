using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocktailMagician.Data.Entities
{
    public class CocktailComment 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The comment cannot be more than 500 characters.")]
        public string Comments { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
