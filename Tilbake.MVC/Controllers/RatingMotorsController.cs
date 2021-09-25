using Microsoft.AspNetCore.Mvc;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class RatingMotorsController : Controller
    {
        private readonly IRatingMotorService _ratingMotor;
        private readonly IInsurerService _insurerService;
        private readonly IPortfolioService _portfolioService;

        public RatingMotorsController(IRatingMotorService ratingMotor,
                                    IInsurerService insurerService,
                                    IPortfolioService portfolioService)
        {
            _ratingMotor = ratingMotor;
            _insurerService = insurerService;
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var insurers = await _insurerService.GetAllAsync();
            return View();
        }

        public async Task<IActionResult> Create(Guid insurerId)
        {
            var resources = await _ratingMotor.GetByInsurerAsync(insurerId);


            return View(resources);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RatingMotorSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _ratingMotor.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }
    }
}
