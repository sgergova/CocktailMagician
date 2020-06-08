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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NToastNotify;

namespace CocktailMagician.Web.Areas.Magician
{
    [Area("Magician")]
    [Authorize(Roles = "Magician")]
    public class CocktailController : Controller
    {
        private readonly ICocktailServices cocktailServices;
        private readonly IIngredientServices ingredientServices;
        private readonly IUploadImagesServices uploadImagesServices;
        private readonly IToastNotification toast;
        public CocktailController(ICocktailServices cocktailServices, IIngredientServices ingredientServices, IUploadImagesServices uploadImagesServices,
                                  IToastNotification toast)
        {
            this.cocktailServices = cocktailServices;
            this.ingredientServices = ingredientServices;
            this.uploadImagesServices = uploadImagesServices;
            this.toast = toast;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCocktail(Guid id)
        {
            if (id == null)
                return NotFound();
            try
            {
                var cocktail = await cocktailServices.DeleteCocktail(id);
                this.toast.AddSuccessToastMessage(Exceptions.SuccessfullyDeleted);
                return RedirectToAction("ListCocktails", "Cocktail");
            }
            catch (Exception)
            {
                this.toast.AddErrorToastMessage(Exceptions.SomethingWentWrong);
                return RedirectToAction("ListCocktails", new { Area = "" });
            }

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
            if (ModelState.IsValid)
            {
                try
                {
                    var cocktailDTO = updatedCocktail.GetDtoFromVM();
                    await cocktailServices.UpdateCocktail(cocktailDTO.Id, cocktailDTO);
                    this.toast.AddSuccessToastMessage(Exceptions.SuccessfullyUpdated);
                    return RedirectToAction("ListCocktails", "Cocktail");
                }
                catch (Exception)
                {
                    this.toast.AddErrorToastMessage(Exceptions.SomethingWentWrong);
                    return RedirectToAction("ListCocktails", new { Area = "" });
                }
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCocktail(CocktailViewModel cocktailVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var image = await uploadImagesServices.UploadImage(cocktailVM.Image);
                    cocktailVM.ImageURL = image;
                    var cocktail = await cocktailServices.CreateCocktail(cocktailVM.GetDtoFromVM());
                    this.toast.AddSuccessToastMessage(Exceptions.SuccessfullyCreated);
                    return RedirectToAction("ListCocktails", "Cocktail", new { Area = "" });
                }
                catch (Exception e)
                {
                    this.toast.AddErrorToastMessage(Exceptions.SomethingWentWrong);
                    return RedirectToAction("ListCocktails", new { Area = "" });
                }
            }
            return NoContent();

        }
        [HttpPost]
        public async Task<IActionResult> AddIngredients(CocktailViewModel model, Guid cocktailId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await cocktailServices.AddIngredientsToCocktail(cocktailId, model.IngredientIds);
                    this.toast.AddSuccessToastMessage($"Successfully added to {model.Name}");
                    return RedirectToAction("ListCocktails", "Cocktail", new { Area = "" });
                }
                catch (Exception e)
                {
                    this.toast.AddErrorToastMessage(Exceptions.SomethingWentWrong);
                    return RedirectToAction("ListCocktails", new { Area = "" });
                }
            }
            return NoContent();

        }
        [HttpPost]
        public async Task<IActionResult> RemoveIngredient(Guid cocktailId, Guid ingredientId)
        {
            try
            {
                var ingredient = await ingredientServices.GetIngredient(ingredientId);
                var cocktail = await cocktailServices.GetCocktail(cocktailId);
                await cocktailServices.RemoveIngredientFromCocktail(cocktail.Name, ingredient.Name);
                this.toast.AddSuccessToastMessage(Exceptions.SuccessfullyDeleted);
                return RedirectToAction("ListCocktails", "Cocktail");
            }
            catch (Exception)
            {
                this.toast.AddErrorToastMessage(Exceptions.SomethingWentWrong);
                return RedirectToAction("ListCocktails", new { Area = "" });
            }
            
        }

    }
}