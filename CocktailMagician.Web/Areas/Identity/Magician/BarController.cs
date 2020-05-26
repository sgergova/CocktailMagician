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
    public class BarController : Controller
    {
        private readonly IBarServices barServices;
        private readonly ICountryServices countryServices;
        private readonly ICocktailServices cocktailServices;
        public BarController(IBarServices barServices, ICountryServices countryServices,ICocktailServices cocktailServices)
        {
            this.barServices = barServices;
            this.countryServices = countryServices;
            this.cocktailServices = cocktailServices;
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBar(Guid id)
        {
            await barServices.DeleteBar(id);


            return RedirectToAction("ListBars", "Bar");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBar(Guid id)
        {
            var barToUpdate = await barServices.GetBar(id);
            var barToUpdateVM = barToUpdate.GetViewModel();

            return View(barToUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBar(BarViewModel updatedBar)
        {
            var barDTO = updatedBar.GetDtoFromVM();
            await barServices.UpdateBar(barDTO.Id, barDTO);

            return RedirectToAction("ListBars", "Bar");
        }
        [HttpPost]
        public async Task<IActionResult> CreateBar(BarViewModel bar)
        {
            var country = await countryServices.GetCountry(bar.CountryName);
            bar.CountryId = country.Id;
            var createdBar = await barServices.CreateBar(bar.GetDtoFromVM());

            return RedirectToAction("ListBars", "Bar");
        }
        [HttpPost]
        public async Task<IActionResult> AddCocktailToBar(Guid barId , Guid cocktailId)
        {
          var cocktail= await cocktailServices.GetCocktail(cocktailId);
            await barServices.AddCocktailToBar(barId, cocktail);
            return RedirectToAction("ListBars", "Bar");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveCocktailFromBar(Guid barId, Guid cocktailId)
        {
            var cocktail = await cocktailServices.GetCocktail(cocktailId);
            await barServices.RemoveCocktailFromBar(barId, cocktailId);
            return RedirectToAction("ListBars", "Bar");
        }

    }
}