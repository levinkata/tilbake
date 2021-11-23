using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class PolicyViewComponent : ViewComponent
    {
        private readonly IPolicyService _policyService;

        public PolicyViewComponent(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid portfolioClientId)
        {
            var ViewModel = await _policyService.GetCurrentPolicyAsync(portfolioClientId);
            return View(ViewModel);
        }
    }
}
