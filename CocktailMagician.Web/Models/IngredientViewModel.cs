using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Models.WebPagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class IngredientViewModel:IPagination<IngredientViewModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool IsAlcoholic { get; set; }
        public string SearchCriteria { get; set; }
        public ICollection<IngredientViewModel> items { get; set; }
        public int currentPage { get; set; }
        public int TotalPages { get; set; }
        public bool hasNext
        {
            get
            {
                return currentPage < TotalPages;
            }
        }
        public bool hasPrev
        {
            get
            {
                return currentPage > 1;
            }
        }
    }
}

