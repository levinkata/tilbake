using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class ReceivablesViewComponent : ViewComponent
    {
        private readonly IReceivableService _receivableService;

        public ReceivablesViewComponent(IReceivableService receivableService)
        {
            _receivableService = receivableService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid invoiceId)
        {
            ViewBag.InvoiceId = invoiceId;
            return View(await _receivableService.GetByInvoiceIdAsync(invoiceId));
        }
    }
}
