using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class CocktailCommentViewModel
    {
        public Guid UserId { get; set; }

        public Guid CocktailId { get; set; }
        //[Bind]
        public string Comment { get; set; }

    }
}
