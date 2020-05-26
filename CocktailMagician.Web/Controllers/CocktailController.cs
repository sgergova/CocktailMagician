using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult>  ListCocktails(string searchOption,string searcher)
        {
            var list = await cocktailServices.GetAllCocktails(null,null,null);
            if (searchOption==null)
            {
                list = await cocktailServices.GetAllCocktails(null, null, null);
            }
            else
            {
                if (searchOption=="name")
                {
                    list = await cocktailServices.GetAllCocktails(searcher, null, null);
                }
            }
            var cocktailViewModels = list.GetViewModels();
            var ingredients = await ingredientServices.GetAllIngredients(null);
            ViewBag.Ingredients = new MultiSelectList(ingredients, "Id", "Name");
            ViewBag.Ing = ingredients;


            return View(cocktailViewModels);
        }
        
        [HttpGet]
        public async Task<IActionResult> CocktailDetails(Guid id)
        {
            var cocktail = await cocktailServices.GetCocktail(id);
            var cocktailVM = cocktail.GetViewModel();
            return View(cocktailVM);
        }
        


    }
}