using System;
using System.Collections.Generic;

namespace CocktailMagician.Data.Entities
{
    public  class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Cocktail> Cocktails { get; set; }
        public List<Bar> Bars { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
