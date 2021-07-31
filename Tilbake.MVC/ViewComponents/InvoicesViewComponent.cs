using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class InvoicesViewComponent : ViewComponent
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesViewComponent(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid portfolioClientId)
        {
            ViewBag.PortfolioClientId = portfolioClientId;
            return View(await Task.Run(() => _invoiceService.GetByPortfolioClientIdAsync(portfolioClientId)));
        }
    }
}
