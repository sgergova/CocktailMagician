using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Data.Entities
{
    public class User : IdentityUser<Guid> 
    {
        public string UserPhoto { get; set; }
        public ICollection<Cocktail> Cocktails { get; set; } = new List<Cocktail>();
        public ICollection<Bar> Bars { get; set; } = new List<Bar>();
        public ICollection<BarComment> BarComments { get; set; } = new List<BarComment>();
        public ICollection<CocktailComment> CocktailComments { get; set; } = new List<CocktailComment>();
        public ICollection<BarRating> BarStars { get; set; } = new List<BarRating>();
        public ICollection<CocktailRating> CocktailStars { get; set; } = new List<CocktailRating>();
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
