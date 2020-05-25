using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Entities
{
   public  class CocktailRating
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public bool Vote { get; set; }

    }
}
