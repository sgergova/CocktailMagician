using System;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Data.Entities
{
    public class BarCocktail 
    {
        public Guid Id { get; set; }
        public Guid BarId { get; set; }
        public Bar Bar { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public bool IsListed { get; set; }
        public DateTime ListedOn { get; set; }
        public DateTime UnlistedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
