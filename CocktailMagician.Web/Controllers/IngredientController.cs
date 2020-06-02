using System;
using System.Threading.Tasks;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CocktailMagician.Web.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientServices ingredientServices;
        private readonly IToastNotification toast;
        public IngredientController(IIngredientServices ingredientServices, IToastNotification toast)
        {
            this.ingredientServices = ingredientServices;
            this.toast = toast;
        }

      
        public async Task<IActionResult> ListIngredients(string orderBy, int? currentPage, string searchCriteria)
        {
            ViewData["SearchParm"] = searchCriteria;

            var ingredients = await this.ingredientServices.GetIndexPageIngredients(orderBy, currentPage ?? 1, searchCriteria);

            var ingViewModels = ingredients.GetViewModels();

            var paged = new IngredientViewModel()
            {
                currentPage = currentPage ?? 1,
                items = ingViewModels,
                TotalPages = this.ingredientServices.GetCount(10, searchCriteria)
            };

            return View(paged);
        }
        [HttpGet]
        public async Task<IActionResult> IngredientDetails(Guid id)
        {
            if (id == null)
                return NotFound();

            try
            {
                var ingredient = await ingredientServices.GetIngredient(id);
                return View(ingredient);
            }
            catch (Exception)
            {
                this.toast.AddWarningToastMessage("Something went wrong!");
                return RedirectToAction("ListIngredients");
            }
        }

    }
}