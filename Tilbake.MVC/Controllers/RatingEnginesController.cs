using Microsoft.AspNetCore.Mvc;
using System;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class RatingEnginesController : Controller
    {
        public IActionResult Index(Guid portfolioId)
        {
            RatingEngineViewModel ViewModel = new();
            ViewModel.PortfolioId = portfolioId;
            return View(ViewModel);
        }
    }
}
