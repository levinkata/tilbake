using Microsoft.AspNetCore.Mvc;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class RatingTablesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
