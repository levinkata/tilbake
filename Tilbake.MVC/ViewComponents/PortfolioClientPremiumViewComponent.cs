using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class PortfolioClientPremiumViewComponent : ViewComponent
    {
        private readonly IPolicyRiskService _policyRiskService;

        public PortfolioClientPremiumViewComponent(IPolicyRiskService policyRiskService)
        {
            _policyRiskService = policyRiskService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid portfolioClientId)
        {
            var ViewModel = await _policyRiskService.GetPremiumByPortfolioClientIdAsync(portfolioClientId);
            return View(ViewModel);
        }
    }
}
