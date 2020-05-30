using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Web.Mappers;
using CocktailMagician.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CocktailMagician.Web.Areas.Identity.Crawler.Controllers
{
    [Area("Crawler")]
    [Authorize(Roles = "Crawler")]
    public class CocktailController : Controller
    {
        private readonly ICocktailCommentServices cocktailCommentServices;
        private readonly ICocktailServices cocktailServices;
        private readonly IToastNotification toast;
        private readonly UserManager<User> manager;
        private readonly ICocktailRatingServices cocktailRatingServices;

        public CocktailController(ICocktailCommentServices cocktailCommentServices, ICocktailServices cocktailServices, IToastNotification toast, UserManager<User> manager,ICocktailRatingServices cocktailRatingServices)
        {

            this.cocktailServices = cocktailServices;
            this.cocktailCommentServices = cocktailCommentServices;
            this.toast = toast;
            this.manager = manager;
            this.cocktailRatingServices = cocktailRatingServices;
        }

        public async Task<IActionResult> CommentOnCocktail(Guid id, CocktailCommentViewModel viewModel)
        {
            viewModel.UserId = Guid.Parse(manager.GetUserId(HttpContext.User));
            viewModel.CocktailId = id;

            await cocktailCommentServices.CreateComment(viewModel.GetDtoFromVM());
            var cocktailId = viewModel.CocktailId;

            return RedirectToAction("Details", "Cocktail", cocktailId);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
                return NotFound();

            try
            {
                var cocktail = await cocktailServices.GetCocktail(id);
                var cocktailVM = cocktail.GetViewModel();
                return View(cocktailVM);
            }
            catch (Exception)
            {
                this.toast.AddErrorToastMessage("Something went wrong");
                return RedirectToAction("ListCocktails", "Cocktail", new { Area = "" });
            }
        }
        public async Task<IActionResult> RateCocktail(int rating, Guid id)
        {
            var viewModel = new CocktailRatingViewModel();
            viewModel.UserId = Guid.Parse(manager.GetUserId(HttpContext.User));
            viewModel.CocktailId = id;
            viewModel.Rating = rating;

            await cocktailRatingServices.CreateRating(viewModel.GetDtoFromVM());


            return RedirectToAction("Details", "Cocktail", id);
        }
    }
}