using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Models.WebPagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class IngredientViewModel:IPagination<CocktailViewModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool IsAlcoholic { get; set; }
        public string SearchCriteria { get; set; }
        public ICollection<CocktailViewModel> items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int currentPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TotalPages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
