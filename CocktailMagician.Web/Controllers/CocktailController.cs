using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CocktailMagician.Web.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ICocktailServices cocktailServices;
        private readonly IIngredientServices ingredientServices;
        public CocktailController(ICocktailServices cocktailServices,IIngredientServices ingredientServices)
        {
            this.cocktailServices = cocktailServices;
            this.ingredientServices = ingredientServices;
        }
        [HttpGet]
        public async Task<IActionResult>  ListCocktails()
        {
            var list = await cocktailServices.GetAllCocktails(null,null,null);
            var cocktailViewModels = list.GetViewModels();
           
           
            return View(cocktailViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCocktail(CocktailViewModel cocktail)
        {
            var country = await cocktailServices.CreateCocktail(cocktail.GetDtoFromVM());
            
           // ViewBag.Categories = new MultiSelectList(categories, "CategoryID", "CategoryName");

            return RedirectToAction("ListCocktails", "Cocktail");
        }
    }
}