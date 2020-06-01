using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CocktailMagician.Web.Controllers
{
    public class BarController : Controller
    {
        private readonly IBarServices barServices;
        private readonly ICountryServices countryServices;
        private readonly IToastNotification toast;
        public BarController(IBarServices barServices, ICountryServices countryServices, IToastNotification toast)
        {
            this.barServices = barServices;
            this.countryServices = countryServices;
            this.toast = toast;
        }
        [HttpGet]
        public async Task<IActionResult> ListBars(string orderBy, int? currentPage, BarViewModel model)
        {
            var searchCriteria = model.SearchCriteria;
            ViewData["CurrentSort"] = orderBy;
            ViewData["NameSortParm"] = orderBy == "name" ? "name_desc" : "name";
            ViewData["SearchParm"] = searchCriteria;

            var bars = await this.barServices.GetIndexPageBars(orderBy, currentPage ?? 1, searchCriteria);

            var countryList = await countryServices.GetAllCountries();
            ViewBag.CountryList = countryList;

            var barsViewModel = bars.GetViewModels();
          
            var paged = new BarViewModel()
            {
                currentPage = currentPage ?? 1,
                items = barsViewModel,
                TotalPages = this.barServices.GetCount(10, searchCriteria)
            };

            return View(paged);
        }

        [HttpGet]
        public async Task<IActionResult> BarDetails(Guid id)
        {
            if (id == null)
                return NotFound();

            try
            {
                var bar = await barServices.GetBar(id);
                var barVM = bar.GetViewModel();
                return View(barVM);
            }
            catch (Exception)
            {
                this.toast.AddErrorToastMessage("Something went wrong");
                return RedirectToAction(nameof(ListBars));
            }
        }
    }
}