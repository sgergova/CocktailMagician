using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CocktailMagician.Data.Entities
{
    public  class User: IdentityUser<Guid>
    {

        public string Name { get; set; }
        public ICollection<Cocktail> Cocktails { get; set; }
        public ICollection<Bar> Bars { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Star> Stars { get; set; }

    }
}
