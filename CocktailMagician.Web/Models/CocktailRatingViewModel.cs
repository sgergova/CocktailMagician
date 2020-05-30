using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class CocktailRatingViewModel
    {
        public Guid UserId { get; set; }

        public Guid CocktailId { get; set; }

        public int Rating { get; set; }
    }
}
