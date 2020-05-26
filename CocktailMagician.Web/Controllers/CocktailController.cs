using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
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
        public async Task<IActionResult>  ListCocktails()
        {
            var list = await cocktailServices.GetAllCocktails(null,null,null);
            var cocktailViewModels = list.GetViewModels();
            var ingredients = await ingredientServices.GetAllIngredients(null);
            ViewBag.Ingredients = new MultiSelectList(ingredients, "Id", "Name");
            ViewBag.Ing = ingredients;


            return View(cocktailViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCocktail(CocktailViewModel cocktail)
        {
            var country = await cocktailServices.CreateCocktail(cocktail.GetDtoFromVM());


            return RedirectToAction("ListCocktails", "Cocktail");
        }
        [HttpGet]
        public async Task<IActionResult> CocktailDetails(Guid id)
        {
            var cocktail = await cocktailServices.GetCocktail(id);
            var cocktailVM = cocktail.GetViewModel();
            return View(cocktailVM);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCocktail(Guid id)
        {
            await cocktailServices.DeleteCocktail(id);


            return RedirectToAction("ListCocktails", "Cocktail");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBar(Guid id)
        {
            var cocktailToUpdate = await cocktailServices.GetCocktail(id);
            var cocktailToUpdateVM = cocktailToUpdate.GetViewModel();

            return View(cocktailToUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBar(CocktailViewModel updatedCocktail)
        {
            var cocktailDTO = updatedCocktail.GetDtoFromVM();
            await cocktailServices.UpdateCocktail(cocktailDTO.Id, cocktailDTO);

            return RedirectToAction("ListCocktails", "Cocktail");
        }



    }
}