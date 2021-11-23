using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    [Authorize]
    public class InvoiceItemsViewComponent : ViewComponent
    {
        private readonly IInvoiceItemService _invoiceItemService;

        public InvoiceItemsViewComponent(IInvoiceItemService invoiceItemService)
        {
            _invoiceItemService = invoiceItemService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid invoiceId)
        {
            var ViewModels = await _invoiceItemService.GetByInvoiceIdAsync(invoiceId);
            return await Task.Run(() => View(ViewModels));
        }
    }
}
