using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

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
            var ViewModels = await _receivableService.GetByInvoiceIdAsync(invoiceId);
            ViewBag.InvoiceId = invoiceId;
            return View(ViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid invoiceId)
        {
            var paymentTypes = await _paymentTypeService.GetAllAsync();

            ReceivableViewModel ViewModel = new()
            {
                InvoiceId = invoiceId,
                ReceivableDate = DateTime.Now,
                PaymentTypeList = SelectLists.PaymentTypes(paymentTypes, Guid.Empty)
            };

            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReceivableViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                await _receivableService.AddAsync(ViewModel);
                return RedirectToAction("Details", "Invoices", new { id = ViewModel.InvoiceId });
            }

            var paymentTypes = await _paymentTypeService.GetAllAsync();
            ViewModel.PaymentTypeList = SelectLists.PaymentTypes(paymentTypes, ViewModel.PaymentTypeId);

            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> QuotePayment(Guid quoteId)
        {
            var paymentTypes = await _paymentTypeService.GetAllAsync();
            var quote = await _quoteService.GetByIdAsync(quoteId);
            var quoteAmount = quote.QuoteItems.Sum(r => r.Premium);

            ReceivableViewModel ViewModel = new()
            {
                QuoteId = quoteId,
                QuoteNumber = quote.QuoteNumber,
                QuoteAmount = quoteAmount,
                ReceivableDate = DateTime.Now,
                PaymentTypeList = SelectLists.PaymentTypes(paymentTypes, Guid.Empty)
            };

            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> QuotePayment(ReceivableViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                await _receivableService.AddQuote(ViewModel);
                return RedirectToAction("Details", "Quotes", new { id = ViewModel.QuoteId });
            }

            var paymentTypes = await _paymentTypeService.GetAllAsync();
            ViewModel.PaymentTypeList = SelectLists.PaymentTypes(paymentTypes, ViewModel.PaymentTypeId);

            return View(ViewModel);
        }

    }
}
