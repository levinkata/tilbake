using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class PortfolioClientSumInsuredViewComponent : ViewComponent
    {
        private readonly IPolicyRiskService _policyRiskService;

        public PortfolioClientSumInsuredViewComponent(IPolicyRiskService policyRiskService)
        {
            _policyRiskService = policyRiskService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid portfolioClientId)
        {
            var resource = await _policyRiskService.GetSumInsuredByPortfolioClientIdAsync(portfolioClientId);
            return View(resource);
        }
    }
}
