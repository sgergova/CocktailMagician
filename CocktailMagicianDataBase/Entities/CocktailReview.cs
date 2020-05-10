using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Entities
{
    public class CocktailReview
    {
        public Guid Id { get; set; }
        public User UserName { get; set; }
        public Guid UserId { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail CocktailName { get; set; }
    }
}
