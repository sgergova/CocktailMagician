using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
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
            var list = await barServices.GetAllBars(null, 0, null, null);
            var barVMList = list.GetViewModels();
            return View(barVMList);
        }
        [HttpGet]
        public async Task<IActionResult> CreateBar()
        {
            
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBar(BarViewModel bar)
        {
            var createdBar = await barServices.CreateBar(bar.GetDtoFromVM());

            return RedirectToAction("ListBars","Bar");
        }
    }
}