using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CocktailMagician.Web.Models;
using CocktailMagician.Web.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using CocktailMagician.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Services;

namespace CocktailMagician.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        private readonly IBarServices barServices;
        private readonly ICocktailServices cocktailServices;
        private readonly IBarRatingServices barRatingServices;

        public HomeController(ILogger<HomeController> logger,IBarServices barServices, ICocktailServices cocktailServices,
                               IBarRatingServices barRatingServices)
        {
            this.barRatingServices = barRatingServices;
            this.logger = logger;
            this.barServices = barServices;
            this.cocktailServices = cocktailServices;
        }

        //TODO: Opravi si pomiite
        public async Task<IActionResult> Index()
        {
            var bars = await barRatingServices.GetRatingOfBar();
            var homeVM = new HomeViewModel();
          //  homeVM.TopThreebars = bars.GetViewModels().Take(3).ToList();

            var cocktails = await cocktailServices.GetAllCocktails();
            homeVM.TopThreeCocktails = cocktails.GetViewModels().Take(3).ToList();

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

    }
}
