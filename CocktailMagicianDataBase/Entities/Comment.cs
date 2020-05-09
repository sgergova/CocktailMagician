using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagicianDataBase.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Comments { get; set; }
        public Guid UserId { get; set; }
        public User UserName { get; set; }
        public Guid? BarId { get; set; }
        public Bar BarName { get; set; }
        public Guid? CocktailId { get; set; }
        public Cocktail CocktailName { get; set; }
    }
}
