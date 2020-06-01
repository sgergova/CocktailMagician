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
    public class BarController : Controller
    {
        private readonly IBarCommentsServices barCommentsServices;
        private readonly IBarServices barServices;
        private readonly IToastNotification toast;
        private readonly UserManager<User> manager;
        private readonly IBarRatingServices barRatingServices;

        public BarController(IBarCommentsServices barCommentsServices,IBarServices barServices, IToastNotification toast,UserManager<User> manager,IBarRatingServices barRatingServices)
        {
            this.barCommentsServices = barCommentsServices;
            this.barServices = barServices;
            this.toast = toast;
            this.manager = manager;
            this.barRatingServices = barRatingServices;
        }
    
       public async Task<IActionResult> CommentOnBar(Guid id,BarCommentViewModel viewModel)
        {
            viewModel.UserId = Guid.Parse(manager.GetUserId(HttpContext.User));
            viewModel.BarId = id;

            await barCommentsServices.CreateComment(viewModel.GetDtoFromVM());
            var barid = viewModel.BarId;

            return RedirectToAction("Details", "Bar", barid);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
                return NotFound();

            try
            {
                var bar = await barServices.GetBar(id);
                var barVM = bar.GetViewModel();

              
                return View(barVM);
            }
            catch (Exception)
            {
                this.toast.AddErrorToastMessage("Something went wrong");
                return RedirectToAction("ListBars", "Bar",new {Area="" });
            }
        }
        public async Task<IActionResult> RateBar(int rating,Guid id)
        {
            var viewModel = new BarRatingViewModel();
            viewModel.UserId = Guid.Parse(manager.GetUserId(HttpContext.User));
            viewModel.BarId = id;
            viewModel.Rating = rating;

            await barRatingServices.CreateRating(viewModel.GetDtoFromVM());


            return RedirectToAction("Details", "Bar", id);
        }
    }
}