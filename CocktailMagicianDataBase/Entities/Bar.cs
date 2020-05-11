using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocktailMagician.Data.Entities
{
    public class Bar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address{ get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public ICollection<Cocktail> Cocktails { get; set; }
        public ICollection<Star> Stars { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string ImageURL { get; set; }
       
        // set google maps
    }

}
