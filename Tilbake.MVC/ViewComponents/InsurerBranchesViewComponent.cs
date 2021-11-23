using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    [Authorize]
    public class InsurerBranchesViewComponent : ViewComponent
    {
        private readonly IInsurerBranchService _insurerBranchService;

        public InsurerBranchesViewComponent(IInsurerBranchService insurerBranchService)
        {
            _insurerBranchService = insurerBranchService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid insurerId)
        {
            ViewBag.InsurerId = insurerId;
            var ViewModels = await _insurerBranchService.GetByInsurerIdAsync(insurerId);
            return View(ViewModels);
        }
    }
}
