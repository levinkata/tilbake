using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class ReceivablesController : Controller
    {
        private readonly IReceivableService _receivableService;
        private readonly IPaymentTypeService _paymentTypeService;
        private readonly IQuoteService _quoteService;

        public ReceivablesController(IReceivableService receivableService,
                                    IPaymentTypeService paymentTypeService,
                                    IQuoteService quoteService)
        {
            _receivableService = receivableService;
            _paymentTypeService = paymentTypeService;
            _quoteService = quoteService;
        }

        public async Task<IActionResult> Index(Guid invoiceId)
        {
            var resources = await _receivableService.GetByInvoiceIdAsync(invoiceId);
            ViewBag.InvoiceId = invoiceId;
            return View(resources);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid invoiceId)
        {
            var paymentTypes = await _paymentTypeService.GetAllAsync();

            ReceivableSaveResource resource = new()
            {
                InvoiceId = invoiceId,
                ReceivableDate = DateTime.Now,
                PaymentTypeList = SelectLists.PaymentTypes(paymentTypes, Guid.Empty)
            };

            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReceivableSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _receivableService.AddAsync(resource);
                return RedirectToAction("Details", "Invoices", new { id = resource.InvoiceId });
            }

            var paymentTypes = await _paymentTypeService.GetAllAsync();
            resource.PaymentTypeList = SelectLists.PaymentTypes(paymentTypes, resource.PaymentTypeId);

            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> QuotePayment(Guid quoteId)
        {
            var paymentTypes = await _paymentTypeService.GetAllAsync();
            var quote = await _quoteService.GetByIdAsync(quoteId);

            ReceivableSaveResource resource = new()
            {
                QuoteId = quoteId,
                QuoteNumber = quote.QuoteNumber,
                ReceivableDate = DateTime.Now,
                PaymentTypeList = SelectLists.PaymentTypes(paymentTypes, Guid.Empty)
            };

            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> QuotePayment(ReceivableSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _receivableService.AddQuoteAsync(resource);
                return RedirectToAction("Details", "Quotes", new { id = resource.QuoteId });
            }

            var paymentTypes = await _paymentTypeService.GetAllAsync();
            resource.PaymentTypeList = SelectLists.PaymentTypes(paymentTypes, resource.PaymentTypeId);

            return View(resource);
        }

    }
}
