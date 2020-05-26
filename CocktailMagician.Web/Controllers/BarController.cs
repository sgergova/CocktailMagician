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
        private readonly ICountryServices countryServices;
        public BarController(IBarServices barServices, ICountryServices countryServices)
        {
            this.barServices = barServices;
            this.countryServices = countryServices;
        }
        [HttpGet]
        public async Task<IActionResult> ListBars(string SearcType,string searcher)
        {
            var list = await barServices.GetAllBars(null, 0, null, null);
            if (searcher==null)
            {
             list = await barServices.GetAllBars(null, 0, null, null);
            }
            else
            {
                if (SearcType=="Name")
                {
                     list = await barServices.GetAllBars(searcher, 0, null, null);
                }
                else if (SearcType == "Rating")
                {
                     list = await barServices.GetAllBars(null, int.Parse(searcher), null, null);
                }
                else if (SearcType == "Address")
                {
                     list = await barServices.GetAllBars(null, 0, searcher, null);
                }
                else if (SearcType == "Country")
                {
                    list = await barServices.GetAllBars(null, 0, null, searcher);
                }

            }
            foreach (var item in list)
            {
                var country = await countryServices.GetCountry(item.CountryId);
                item.CountryName = country.Name;
            }
            var barVMList = list.GetViewModels();
         
            var countryList = await countryServices.GetAllCountries();
            ViewBag.CountryList = countryList;
            return View(barVMList);
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