using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class BarCommentViewModel
    {

        public Guid UserId { get; set; }

        public Guid BarId { get; set; }
        //[Bind]
        public string Comment { get; set; }

    }
}
