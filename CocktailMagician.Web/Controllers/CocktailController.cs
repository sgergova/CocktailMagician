using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CocktailMagician.Web.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ICocktailServices cocktailServices;
        private readonly IIngredientServices ingredientServices;
        public CocktailController(ICocktailServices cocktailServices,IIngredientServices ingredientServices)
        {
            this.cocktailServices = cocktailServices;
            this.ingredientServices = ingredientServices;
        }
        [HttpGet]
        public async Task<IActionResult>  ListCocktails(string orderBy, int? currentPage, string searchCriteria, string type)
        {

            ViewData["CurrentSort"] = orderBy;
            ViewData["NameSortParm"] = orderBy == "name" ? "name_desc" : "name";
            ViewData["SearchParm"] = searchCriteria;
            ICollection<CocktailDTO> bars = new List<CocktailDTO>();

            bars = await this.cocktailServices.GetIndexPageCocktails(orderBy, currentPage ?? 1, searchCriteria);

            var ingredients = await ingredientServices.GetAllIngredients(null);
            ViewBag.Ingredients = new MultiSelectList(ingredients, "Id", "Name");
            ViewBag.Ing = ingredients; 

            var barsViewModel = bars.GetViewModels();
            var paged = new CocktailViewModel()
            {
                currentPage = currentPage ?? 1,
                items = barsViewModel,
                TotalPages = this.cocktailServices.GetCount(10, searchCriteria, type)
            };

            return View(paged);
        }
        
        [HttpGet]
        public async Task<IActionResult> CocktailDetails(Guid id)
        {
            var cocktail = await cocktailServices.GetCocktail(id);
            var cocktailVM = cocktail.GetViewModel();
            return View(cocktailVM);
        }
        


    }
}