using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services.CommonMessages;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CocktailMagician.Web.Areas.Magician
{
    [Area("Magician")]
    [Authorize(Roles = "Magician")]
    public class IngredientController : Controller
    {
        private readonly IIngredientServices ingredientServices;
        private readonly IToastNotification toast;
        public IngredientController(IIngredientServices ingredientServices, IToastNotification toast)
        {
            this.ingredientServices = ingredientServices;
            this.toast = toast;
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateIngredient(IngredientViewModel ingredient)
        //{
        //    var ingredientToCreate = await ingredientServices.CreateIngredient(ingredient)./*GetDTOFromVM());*/

        //    return RedirectToAction("ListIngredients", "Ingredient");
        //}
        [HttpPost]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            try
            {
                await ingredientServices.DeleteIngredient(id);
                this.toast.AddSuccessToastMessage(Exceptions.SuccessfullyDeleted);
                return RedirectToAction("ListIngredients", "Ingredient");
            }
            catch (Exception)
            {
                this.toast.AddErrorToastMessage(Exceptions.SomethingWentWrong);
                return RedirectToAction("ListIngredients");
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> UpdateIngredient(Guid id)
        {
            var ingredientToUpdate = await ingredientServices.GetIngredient(id);
            var ingredientToUpdateVM = ingredientToUpdate.GetViewModel();

            return View(ingredientToUpdateVM);
        }
        //[HttpPost]
        //public async Task<IActionResult> UpdateBar(IngredientViewModel updatedIngredient)
        //{
        //    var ingredientDTO = updatedIngredient.GetDtoFromVM();
        //    await ingredientServices.UpdateIngredient(ingredientDTO.Id, ingredientDTO);

        //    return RedirectToAction("ListIngredients", "Ingredient");
        //}

    }
}