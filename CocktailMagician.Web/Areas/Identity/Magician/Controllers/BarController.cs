using System;
using System.Threading.Tasks;
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
                this.toastNotification.AddWarningToastMessage("Something went wrong!");
                return RedirectToAction("ListBars");
            }
          
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBar(BarViewModel updatedBar)
        {
            try
            {
                var barDTO = updatedBar.GetDtoFromVM();
                await barServices.UpdateBar(barDTO.Id, barDTO);

                return RedirectToAction("ListBars", "Bar");

            }
            catch (Exception)
            {
                this.toastNotification.AddWarningToastMessage("Something went wrong!");
                return RedirectToAction("ListBars");
            }
            
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

                    return RedirectToAction("ListBars", "Bar", new { Area=""});
                }
                catch (Exception)
                {
                    this.toastNotification.AddErrorToastMessage("Ooops... something went wrong");
                    return RedirectToAction("ListBars");
                }
            }
            return NoContent();
        }



        [HttpPost]
        public async Task<IActionResult> AddCocktailToBar(Guid barId, Guid cocktailId)
        {
            try
            {
                var cocktail = await cocktailServices.GetCocktail(cocktailId);
                await barServices.AddCocktailToBar(barId, cocktail);
                return RedirectToAction("ListBars", "Bar");
            }
            catch (Exception)
            {
                this.toastNotification.AddErrorToastMessage("Ooops... something went wrong");
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
                this.toastNotification.AddErrorToastMessage("Ooops... something went wrong");
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
                this.toastNotification.AddSuccessToastMessage($"{barToDelete.Name} was deleted successfully!");

                return RedirectToAction("ListBars", "Bar",new { Area="" });

            }
            catch (Exception)
            {
                this.toastNotification.AddErrorToastMessage("Ooops... something went wrong");
                return RedirectToAction("ListBars");
            }
        }
    }
}