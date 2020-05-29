using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class HomeViewModel
    {
        public ICollection<BarViewModel> TopThreebars { get; set; }
        public ICollection<CocktailViewModel> TopThreeCocktails { get; set; }
    }
}
