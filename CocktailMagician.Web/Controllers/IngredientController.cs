using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services.Contracts;
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

        public async Task<IActionResult> CreateIngredient(IngredientViewModel ingredient)
        {
            var ingredientToCreate = await ingredientServices.CreateIngredient(ingredient.GetDTOFromVM());

           return RedirectToAction("ListIngredients", "Ingredient");
        }
        public async Task<IActionResult> ListIngredients()
        {
            var list = await ingredientServices.GetAllIngredients(null);
            var ingredientsViewModels = list.GetViewModels();
          
            return View(ingredientsViewModels);
        }
        [HttpGet]
        public async Task<IActionResult> IngredientDetails(Guid id)
        {
            var ingredient = await ingredientServices.GetIngredient(id);

            return View(ingredient);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            await ingredientServices.DeleteIngredient(id);


            return RedirectToAction("ListIngredients", "Ingredient");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateIngredient(Guid id)
        {
            var ingredientToUpdate = await ingredientServices.GetIngredient(id);
            var ingredientToUpdateVM = ingredientToUpdate.GetViewModel();

            return View(ingredientToUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBar(IngredientViewModel updatedIngredient)
        {
            var ingredientDTO = updatedIngredient.GetDtoFromVM();
            await ingredientServices.UpdateIngredient(ingredientDTO.Id, ingredientDTO);

            return RedirectToAction("ListIngredients", "Ingredient");
        }

    }
}