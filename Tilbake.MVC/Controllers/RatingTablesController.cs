using Microsoft.AspNetCore.Mvc;
using Tilbake.Application.Resources;

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
