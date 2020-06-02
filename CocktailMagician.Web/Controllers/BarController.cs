using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ICocktailServices cocktailServices;

        public BarController(IBarServices barServices, ICountryServices countryServices, IToastNotification toast, UserManager<User> manager,IBarCommentsServices barCommentsServices,ICocktailServices cocktailServices)
        {
            this.barServices = barServices;
            this.countryServices = countryServices;
            this.toast = toast;
            this.manager = manager;
            this.barCommentsServices = barCommentsServices;
            this.cocktailServices = cocktailServices;
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
            var cocktails = await this.cocktailServices.GetAllCocktails();
            if (id == null)
                return NotFound();

            try
            {
                var bar = await barServices.GetBar(id);
                var barVM = bar.GetViewModel();
                var comments = await barCommentsServices.GetAllCommentsOfBar(id);
                barVM.CocktailsToChoose = cocktails.Select(c => new SelectListItem(c.Name, c.Name)).ToList();
                barVM.BarCocktails = await barServices.GetCocktailsForBar(id);
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