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
    public class BarController : Controller
    {
        private readonly IBarServices barServices;
        private readonly ICountryServices countryServices;
        public BarController(IBarServices barServices, ICountryServices countryServices)
        {
            this.barServices = barServices;
            this.countryServices = countryServices;
        }
        [HttpGet]
        public async Task<IActionResult> ListBars(string orderBy, int? currentPage, string searchCriteria, string type)
        {
            ViewData["CurrentSort"] = orderBy;
            ViewData["NameSortParm"] = orderBy == "name" ? "name_desc" : "name";
            ViewData["SearchParm"] = searchCriteria;
            ICollection<BarDTO> bars = new List<BarDTO>();

            bars = await this.barServices.GetIndexPageBars(orderBy, currentPage ?? 1, searchCriteria);

            var countryList = await countryServices.GetAllCountries();
            ViewBag.CountryList = countryList;

            var barsViewModel = bars.GetViewModels();
            var paged = new BarViewModel()
            {
                currentPage = currentPage ?? 1,
                items = barsViewModel,
                TotalPages = this.barServices.GetCount(10, searchCriteria, type)
            };

            return View(paged);
        }

        [HttpGet]
        public async Task<IActionResult> BarDetails(Guid id)
        {
            var bar = await barServices.GetBar(id);
            var barVM = bar.GetViewModel();
            return View(barVM);
        }

    }
}