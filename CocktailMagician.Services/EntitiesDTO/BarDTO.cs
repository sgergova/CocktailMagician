using CocktailMagician.Data.Entities;
using System;
using System.Collections.Generic;

namespace CocktailMagician.Services.EntitiesDTO
{
    public class BarDTO 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public ICollection<BarCocktail> BarCocktails { get; set; }
        public ICollection<BarRating> Stars { get; set; }
        public ICollection<BarComment> Comments { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
