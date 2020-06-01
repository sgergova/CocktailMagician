using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CocktailMagician.Web.Controllers
{
    public class BarController : Controller
    {
        private readonly IBarServices barServices;
        private readonly ICountryServices countryServices;
        private readonly IToastNotification toast;
        private readonly UserManager<User> manager;
        private readonly IBarCommentsServices barCommentsServices;

        public BarController(IBarServices barServices, ICountryServices countryServices, IToastNotification toast, UserManager<User> manager,IBarCommentsServices barCommentsServices)
        {
            this.barServices = barServices;
            this.countryServices = countryServices;
            this.toast = toast;
            this.manager = manager;
            this.barCommentsServices = barCommentsServices;
        }
        [HttpGet]
        public async Task<IActionResult> ListBars(string orderBy, int? currentPage, BarViewModel model)
        {
            var searchCriteria = model.SearchCriteria;
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
                var comments = await barCommentsServices.GetAllCommentsOfBar(id);
                barVM.Comments = comments.GetViewModels();
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