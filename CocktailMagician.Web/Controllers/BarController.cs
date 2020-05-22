﻿using System;
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
        public BarController(IBarServices barServices,ICountryServices countryServices)
        {
            this.barServices = barServices;
            this.countryServices = countryServices;
        }
       [HttpGet]
        public async Task<IActionResult> ListBars()
        {
            var list = await barServices.GetAllBars(null, 0, null, null);
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
        [HttpPost]
        public async Task<IActionResult> CreateBar(BarViewModel bar)
        {
            var country = await countryServices.GetCountry(bar.CountryName);
            bar.CountryId = country.Id;
            var createdBar = await barServices.CreateBar(bar.GetDtoFromVM());

            return RedirectToAction("ListBars","Bar");
        }
        [HttpGet]
        public async Task<IActionResult> BarDetails(Guid id)
        {
            var bar = await barServices.GetBar(id);
            var barVM =  bar.GetViewModel();
            return View(barVM);
        }


    }
}