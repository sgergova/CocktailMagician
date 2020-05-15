using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CocktailMagician.Web.Controllers
{
    public class BarController : Controller
    {
        private readonly IBarServices barServices;
        public BarController(IBarServices barServices)
        {
            this.barServices = barServices;
        }
       [HttpGet]
        public async Task<IActionResult> ListBars()
        {
            var list = await barServices.GetAllBars(null, 0, null);
            var barVMList = list.GetViewModels();
            return View(barVMList);
        }
    }
}