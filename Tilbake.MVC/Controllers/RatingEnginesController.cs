using Microsoft.AspNetCore.Mvc;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class RatingEnginesController : Controller
    {
        public IActionResult Index(Guid portfolioId)
        {
            RatingEngineResource resource = new();
            resource.PortfolioId = portfolioId;
            return View(resource);
        }
    }
}
