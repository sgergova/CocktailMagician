using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CocktailMagician.Web.Areas.Magician
{
    [Area("Magician")]
    [Authorize(Roles = "Magician")]
    public class CocktailController : Controller
    {
        private readonly ICocktailServices cocktailServices;
        private readonly IIngredientServices ingredientServices;
        public CocktailController(ICocktailServices cocktailServices, IIngredientServices ingredientServices)
        {
            this.cocktailServices = cocktailServices;
            this.ingredientServices = ingredientServices;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCocktail(Guid id)
        {
            await cocktailServices.DeleteCocktail(id);


            return RedirectToAction("ListCocktails", "Cocktail");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCocktail(Guid id)
        {
            var cocktailToUpdate = await cocktailServices.GetCocktail(id);
            var cocktailToUpdateVM = cocktailToUpdate.GetViewModel();

            return View(cocktailToUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCocktail(CocktailViewModel updatedCocktail)
        {
            var cocktailDTO = updatedCocktail.GetDtoFromVM();
            await cocktailServices.UpdateCocktail(cocktailDTO.Id, cocktailDTO);

            return RedirectToAction("ListCocktails", "Cocktail");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCocktail(CocktailViewModel cocktailVM)
        {
            var cocktail = await cocktailServices.CreateCocktail(cocktailVM.GetDtoFromVM());


            return RedirectToAction("ListCocktails", "Cocktail", new {Area="" });
        }
        [HttpPost]
        public async Task<IActionResult> AddIngredients(CocktailViewModel model,string name)
        {
           

            await cocktailServices.AddIngredientsToCocktail(name, model.IngredientNames.ToList());

            return RedirectToAction("ListCocktails", "Cocktail", new {Area="" });
        }
        [HttpPost]
        public async Task<IActionResult> RemoveIngredient(Guid cocktailId, Guid ingredientId)
        {
            var ingredient = await ingredientServices.GetIngredient(ingredientId);
            var cocktail = await cocktailServices.GetCocktail(cocktailId);

            await cocktailServices.RemoveIngredientFromCocktail(cocktail.Name, ingredient.Name);

            return RedirectToAction("ListCocktails", "Cocktail");
        }
       
    }
}