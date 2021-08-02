using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class PoliciesViewComponent : ViewComponent
    {
        private readonly IPolicyService _policyService;
        
        public PoliciesViewComponent(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid portfolioClientId)
        {
            ViewBag.PortfolioClientId = portfolioClientId;
            return View(await Task.Run(() => _policyService.GetByPorfolioClientIdAsync(portfolioClientId)));
        }
    }
}