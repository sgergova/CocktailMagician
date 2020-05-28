using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocktailMagician.Data.Entities
{
    public class Bar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<BarCocktail> BarCocktails { get; set; } = new List<BarCocktail>();
        public ICollection<BarRating> BarRating { get; set; } = new List<BarRating>();
        public ICollection<BarComment> Comments { get; set; } = new List<BarComment>();
        [Url]
        public string BarImageURL { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

        // set google maps
    }
}
