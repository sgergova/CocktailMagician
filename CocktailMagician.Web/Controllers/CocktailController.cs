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
using NToastNotify;

namespace CocktailMagician.Web.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ICocktailServices cocktailServices;
        private readonly IIngredientServices ingredientServices;
        private readonly IToastNotification toast;
        private readonly ICocktailCommentServices cocktailCommentServices;

        public CocktailController(ICocktailServices cocktailServices,IIngredientServices ingredientServices, IToastNotification toast,ICocktailCommentServices cocktailCommentServices)
        {
            this.cocktailServices = cocktailServices;
            this.ingredientServices = ingredientServices;
            this.toast = toast;
            this.cocktailCommentServices = cocktailCommentServices;
        }
        [HttpGet]
        public async Task<IActionResult>  ListCocktails(string orderBy, int? currentPage, CocktailViewModel model)
        {
            var searchCriteria = model.SearchCriteria;
            ViewData["CurrentSort"] = orderBy;
            ViewData["NameSortParm"] = orderBy == "name" ? "name_desc" : "name";
            ViewData["SearchParm"] = searchCriteria;
            ICollection<CocktailDTO> bars = new List<CocktailDTO>();

            bars = await this.cocktailServices.GetIndexPageCocktails(orderBy, currentPage ?? 1, searchCriteria);

            var ingredients = await ingredientServices.GetAllIngredients(null);

            var barsViewModel = bars.GetViewModels();
            var paged = new CocktailViewModel()
            {
                IngredientsToChoose = ingredients.Select(c => new SelectListItem(c.Name, c.Name)).ToList(),
                currentPage = currentPage ?? 1,
                items = barsViewModel,
                TotalPages = this.cocktailServices.GetCount(10, searchCriteria)
            };

            return View(paged);
        }
        
        [HttpGet]
        public async Task<IActionResult> CocktailDetails(Guid id)
        {
            var ingredients = await ingredientServices.GetAllIngredients(null);
            if (id == null)
                return NotFound();

            try
            {
                var cocktail = await cocktailServices.GetCocktail(id);
                var cocktailVM = cocktail.GetViewModel();
                cocktailVM.IngredientsToChoose = ingredients.Select(c => new SelectListItem(c.Name, c.Name)).ToList();
                cocktailVM.Ingredients = await ingredientServices.GetCocktailIngredients(id);
                cocktailVM.Bars = await cocktailServices.GetBarsForCocktail(id);
                var comments = await cocktailCommentServices.GetAllCommentsForCocktail(id);
                cocktailVM.Comments = comments.GetViewModels();
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