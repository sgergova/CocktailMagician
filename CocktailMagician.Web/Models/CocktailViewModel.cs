using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Models.WebPagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class CocktailViewModel :IPagination<CocktailViewModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public double AlcoholPercentage { get; set; }
        public bool IsAlcoholic { get; set; }
        public string ImageURL { get; set; }
        public ICollection<CocktailIngredientDTO> Ingredients { get; set; }
        public ICollection<IngredientDTO> IngredientsForCocktail { get; set; }
        public ICollection<BarCocktailDTO> Bars { get; set; }
        public ICollection<BarRating> Stars { get; set; }
        public ICollection<CocktailCommentsDTO> Comments { get; set; }
        public ICollection<CocktailViewModel> items { get; set; }
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
