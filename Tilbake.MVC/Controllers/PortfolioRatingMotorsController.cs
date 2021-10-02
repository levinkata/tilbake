using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class PortfolioRatingMotorsController : Controller
    {
        // private readonly IRatingMotorService _ratingMotor;
        // private readonly IInsurerService _insurerService;
        private readonly IPortfolioService _portfolioService;

        public PortfolioRatingMotorsController(// IRatingMotorService ratingMotor,
                                    // IInsurerService insurerService,
                                    IPortfolioService portfolioService)
        {
            // _ratingMotor = ratingMotor;
            // _insurerService = insurerService;
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index(Guid portfolioId, Guid insurerId)
        {
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            PortfolioRatingMotorResource resource = new()
            {
                PortfolioId = portfolioId,
                InsurerId = insurerId,
                PortfolioName = portfolio.Name
            };

            return View(resource);
        }
    }
}
