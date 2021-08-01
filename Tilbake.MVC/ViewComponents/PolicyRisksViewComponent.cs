using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    [Authorize]
    public class PolicyRisksViewComponent : ViewComponent
    {
        private readonly IPolicyRiskService _PolicyRiskService;

        public PolicyRisksViewComponent(IPolicyRiskService PolicyRiskService)
        {
            _PolicyRiskService = PolicyRiskService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid policyId)
        {
            var resources = await _PolicyRiskService.GetByPolicyIdAsync(policyId);
            return View(resources);
        }
    }
}
