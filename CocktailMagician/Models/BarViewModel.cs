using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class BarViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public string ImageURL { get; set; }
        public ICollection<BarCocktailDTO> BarCocktails { get; set; }
        public ICollection<BarStar> Stars { get; set; }
        public ICollection<BarCommentDTO> Comments { get; set; }
    }
}
