using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class BarCommentViewModel
    {

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Guid BarId { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The comment cannot be more than 500 characters.")]
        public string Comment { get; set; }
      

    }
}
