using System;
using System.Collections.Generic;

namespace CocktailMagician.Data.Entities
{
    public class Bar
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address{ get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public List<Cocktail> Cocktails { get; set; }
        public List<Reservation> Reservations { get; set; }
        public string ImageURL { get; set; }
       
        // set google maps
    }
}
