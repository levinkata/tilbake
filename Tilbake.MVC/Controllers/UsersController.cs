using Microsoft.AspNetCore.Mvc;

namespace Tilbake.MVC.Controllers
{
    public class UsersController : Controller
    {

        public UsersController()
        {

        }

        public IActionResult Claims()
        {
            return View();
        }
    }
}
