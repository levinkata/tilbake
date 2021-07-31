using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Application.Services;

namespace Tilbake.MVC.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceStatusService _invoiceStatusService;
        private readonly ITaxService _taxService;

        public InvoicesController(IInvoiceService invoiceService,
                                 IInvoiceStatusService invoiceStatusService,
                                 ITaxService taxService)
        {
            _invoiceStatusService = invoiceStatusService;
            _taxService = taxService;
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid policyId)
        {
            var invoiceStatuses = await _invoiceStatusService.GetAllAsync();
            var taxes = await _taxService.GetAllAsync();

            InvoiceSaveResource resource = new()
            {
                PolicyId = policyId,
                InvoiceStatusList = SelectLists.InvoiceStatuses(invoiceStatuses, Guid.Empty),
                TaxList = SelectLists.Taxes(taxes, Guid.Empty)
            };
            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostInvoice(InvoiceSaveResource resource)
        {
            return await Task.Run(() => View(resource));
        }
    }
}