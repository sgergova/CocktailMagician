using System;
using System.Collections.Generic;
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
    public class BarController : Controller
    {
        private readonly IBarServices barServices;
        private readonly ICountryServices countryServices;
        private readonly ICocktailServices cocktailServices;
        private readonly IUploadImagesServices uploadImagesServices;
        private readonly IToastNotification toastNotification;

        public BarController(IBarServices barServices, ICountryServices countryServices, ICocktailServices cocktailServices,
                                                       IUploadImagesServices uploadImagesServices, IToastNotification toastNotification)
        {
            this.barServices = barServices;
            this.countryServices = countryServices;
            this.cocktailServices = cocktailServices;
            this.uploadImagesServices = uploadImagesServices;
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBar(Guid id)
        {
            try
            {
                var barToUpdate = await barServices.GetBar(id);
                var barToUpdateVM = barToUpdate.GetViewModel();

                return View(barToUpdateVM);
            }
            catch (Exception)
            {
                this.toastNotification.AddWarningToastMessage(Exceptions.SomethingWentWrong);
                return RedirectToAction("ListBars");
            }

        }
        [HttpPost]
        public async Task<IActionResult> UpdateBar(BarViewModel updatedBar)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var barDTO = updatedBar.GetDtoFromVM();
                    await barServices.UpdateBar(barDTO.Id, barDTO);
                    this.toastNotification.AddSuccessToastMessage(Exceptions.SuccessfullyUpdated);
                    return RedirectToAction("ListBars", "Bar");

                }
                catch (Exception)
                {
                    this.toastNotification.AddWarningToastMessage(Exceptions.SomethingWentWrong);
                    return RedirectToAction("ListBars");
                }
            }
            return View(updatedBar);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBar(BarViewModel bar)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var country = await countryServices.GetCountry(bar.CountryName);
                    bar.CountryId = country.Id;

                    var image = await uploadImagesServices.UploadImage(bar.Image);
                    bar.ImageURL = image;
                    var createdBar = await barServices.CreateBar(bar.GetDtoFromVM());
                    this.toastNotification.AddSuccessToastMessage(Exceptions.SuccessfullyCreated);
                    return RedirectToAction("ListBars", "Bar", new { Area = "" });
                }
                catch (Exception)
                {
                    this.toastNotification.AddErrorToastMessage(Exceptions.SomethingWentWrong);
                    return RedirectToAction("ListBars");
                }
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddCocktailToBar(Guid barId, BarViewModel model)
        {
            try
            {
                //if (model.CocktailsId.Count > 1)
                    await this.barServices.AddCocktailsToBar(barId, model.CocktailsId);
                //else
                //{
                //    ;
                //    var cocktail = await cocktailServices.GetCocktail();
                //    await barServices.AddCocktailToBar(barId, cocktail.Id);
                //}
                return RedirectToAction("ListBars", "Bar", new { Area=""});
            }
            catch (Exception e)
            {
                this.toastNotification.AddErrorToastMessage(Exceptions.SomethingWentWrong);
                return RedirectToAction("ListBars");
            }

        }
        [HttpPost]
        public async Task<IActionResult> RemoveCocktailFromBar(Guid barId, Guid cocktailId)
        {
            try
            {
                var cocktail = await cocktailServices.GetCocktail(cocktailId);
                await barServices.RemoveCocktailFromBar(barId, cocktailId);
                return RedirectToAction("ListBars", "Bar");

            }
            catch (Exception)
            {
                this.toastNotification.AddErrorToastMessage(Exceptions.SomethingWentWrong);
                return RedirectToAction("ListBars");
            }

        }

        //[HttpPost]
        public async Task<IActionResult> DeleteBar(Guid id)
        {

            if (id == null)
                return NotFound();

            try
            {
                var barToDelete = await barServices.DeleteBar(id);
                this.toastNotification.AddSuccessToastMessage(Exceptions.SuccessfullyDeleted);

                return RedirectToAction("ListBars", "Bar", new { Area = "" });

            }
            catch (Exception)
            {
                this.toastNotification.AddErrorToastMessage(Exceptions.SomethingWentWrong);
                return RedirectToAction("ListBars");
            }
        }
    }
}