using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class BarRatingViewModel
    {
        public Guid UserId { get; set; }

        public Guid BarId { get; set; }

        public int Rating { get; set; }
    }
}
