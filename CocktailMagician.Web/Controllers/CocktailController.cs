using System;
using System.Threading.Tasks;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace CocktailMagician.Web.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ICocktailServices cocktailServices;
        private readonly IIngredientServices ingredientServices;
        private readonly IToastNotification toast;

        public CocktailController(ICocktailServices cocktailServices,IIngredientServices ingredientServices, IToastNotification toast)
        {
            this.cocktailServices = cocktailServices;
            this.ingredientServices = ingredientServices;
            this.toast = toast;
        }
        [HttpGet]
        public async Task<IActionResult>  ListCocktails(string orderBy, int? currentPage, CocktailViewModel model)
        {
            var searchCriteria = model.SearchCriteria;
            ViewData["CurrentSort"] = orderBy;
            ViewData["NameSortParm"] = orderBy == "name" ? "name_desc" : "name";
            ViewData["SearchParm"] = searchCriteria;

            var cocktails = await this.cocktailServices.GetIndexPageCocktails(orderBy, currentPage ?? 1, searchCriteria);

            var ingredients = await ingredientServices.GetAllIngredients(null);
            ViewBag.Ingredients = new MultiSelectList(ingredients, "Id", "Name");
            ViewBag.Ing = ingredients; 

            var cocktailViewModel = cocktails.GetViewModels();
            var paged = new CocktailViewModel()
            {
                currentPage = currentPage ?? 1,
                items = cocktailViewModel,
                TotalPages = this.cocktailServices.GetCount(10, searchCriteria)
            };

            return View(paged);
        }
        
        [HttpGet]
        public async Task<IActionResult> CocktailDetails(Guid id)
        {
            if (id == null)
                return NotFound();

            try
            {
                var cocktail = await cocktailServices.GetCocktail(id);
                var cocktailVM = cocktail.GetViewModel();
               
                return View(cocktailVM);
            }
            catch (Exception)
            {
                this.toast.AddErrorToastMessage("Something went wrong");
                return RedirectToAction("ListBars");
            }
        }
    }
}