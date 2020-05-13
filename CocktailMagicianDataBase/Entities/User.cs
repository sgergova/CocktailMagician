using CocktailMagician.Data.Entities.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Data.Entities
{
    public class User : IdentityUser<Guid>, IEntitiesDetails
    {
        [Required]
        [StringLength(30, ErrorMessage = "The username cannot be more than 30 characters")]
        public string Name { get; set; }
        public ICollection<Cocktail> Cocktails { get; set; }
        public ICollection<Bar> Bars { get; set; }
        public ICollection<BarComment> BarComments { get; set; }
        public ICollection<CocktailComment> CocktailComments { get; set; }
        public ICollection<BarStar> BarStars { get; set; }
        public ICollection<CocktailStar> CocktailStars { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
