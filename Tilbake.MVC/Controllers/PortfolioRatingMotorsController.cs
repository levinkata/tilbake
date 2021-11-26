using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class PortfolioRatingMotorsController : BaseController
    {
        public PortfolioRatingMotorsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid portfolioId, Guid insurerId)
        {
            var portfolio = await _unitOfWork.Portfolios.GetById(portfolioId);

            PortfolioRatingMotorViewModel model = new()
            {
                PortfolioId = portfolioId,
                InsurerId = insurerId,
                PortfolioName = portfolio.Name
            };

            return View(model);
        }
    }
}
