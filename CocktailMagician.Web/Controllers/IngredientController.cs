using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CocktailMagician.Web.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientServices ingredientServices;
        public IngredientController(IIngredientServices ingredientServices)
        {
            this.ingredientServices = ingredientServices;
        }

      
        public async Task<IActionResult> ListIngredients(string orderBy, int? currentPage, IngredientViewModel model)
        {
            var searchCriteria = model.SearchCriteria;
            ViewData["CurrentSort"] = orderBy;
            ViewData["NameSortParm"] = orderBy == "name" ? "name_desc" : "name";
            ViewData["SearchParm"] = searchCriteria;
            ICollection<IngredientDTO> ingredients = new List<IngredientDTO>();

            ingredients = await this.ingredientServices.GetIndexPageIngredients(orderBy, currentPage??1, searchCriteria);

           

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
            var ingredient = await ingredientServices.GetIngredient(id);

            return View(ingredient);
        }
      

    }
}