using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Entities
{
    public class Star
    {
        public Guid UserId { get; set; }
        public User UserName { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail CocktailName { get; set; }
        public Guid BarId { get; set; }
        public Bar BarName { get; set; }
        public bool Vote { get; set; }
    }
}
