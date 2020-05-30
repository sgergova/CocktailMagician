using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CocktailMagician.Web.Areas.Identity.Crawler.Controllers
{
    public class BarCommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}