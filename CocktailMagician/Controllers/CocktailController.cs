using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CocktailMagician.Web.Controllers
{
    public class CocktailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}