using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    [Authorize]
    public class BankBranchesViewComponent : ViewComponent
    {
        private readonly IBankBranchService _bankBranchService;

        public BankBranchesViewComponent(IBankBranchService bankBranchService)
        {
            _bankBranchService = bankBranchService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid bankId)
        {
            ViewBag.BankId = bankId;
            var ViewModels = await _bankBranchService.GetByBankIdAsync(bankId);
            return View(ViewModels);
        }
    }
}
