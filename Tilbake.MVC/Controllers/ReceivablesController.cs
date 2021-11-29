using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Helpers;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class ReceivablesController : BaseController
    {
        public ReceivablesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid invoiceId)
        {
            var result = await _unitOfWork.Receivables.GetByInvoiceId(invoiceId);
            ViewBag.InvoiceId = invoiceId;
            var model = _mapper.Map<IEnumerable<Receivable>, IEnumerable<ReceivableViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid invoiceId)
        {
            var paymentTypes = await _unitOfWork.PaymentTypes.GetAll(r => r.OrderBy(n => n.Name));

            ReceivableViewModel model = new()
            {
                InvoiceId = invoiceId,
                ReceivableDate = DateTime.Now,
                PaymentTypeList = MVCHelperExtensions.ToSelectList(paymentTypes, Guid.Empty)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReceivableViewModel model)
        {
            if (ModelState.IsValid)
            {
                var receivable = _mapper.Map<ReceivableViewModel, Receivable>(model);
                var invoiceId = model.InvoiceId;

                var invoice = await _unitOfWork.Invoices.GetById(invoiceId);
                var policyId = invoice.PolicyId;

                receivable.Id = Guid.NewGuid();
                receivable.DateAdded = DateTime.Now;
                await _unitOfWork.Receivables.Add(receivable);

                ReceivableInvoice receivableInvoice = new()
                {
                    InvoiceId = model.InvoiceId,
                    ReceivableId = receivable.Id
                };
                await _unitOfWork.ReceivableInvoices.Add(receivableInvoice);

                Premium newPremium = new()
                {
                    Id = Guid.NewGuid(),
                    PolicyId = policyId,
                    PremiumDate = DateTime.Now,
                    PremiumMonth = 0,
                    PremiumYear = 0,
                    Amount = 0,
                    IsRefunded = false,
                    Commission = 0,
                    TaxAmount = 0,
                    PolicyFee = 0,
                    AdministrationFee = 0,
                    DateAdded = DateTime.Now
                };
                await _unitOfWork.Premiums.Add(newPremium);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Details", "Invoices", new { id = invoiceId });
            }

            var paymentTypes = await _unitOfWork.PaymentTypes.GetAll(r => r.OrderBy(n => n.Name));
            model.PaymentTypeList = MVCHelperExtensions.ToSelectList(paymentTypes, model.PaymentTypeId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> QuotePayment(Guid quoteId)
        {
            var paymentTypes = await _unitOfWork.PaymentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var quote = await _unitOfWork.Quotes.GetById(quoteId);
            var quoteAmount = quote.QuoteItems.Sum(r => r.Premium);

            ReceivableViewModel model = new()
            {
                QuoteId = quoteId,
                QuoteNumber = quote.QuoteNumber,
                QuoteAmount = quoteAmount,
                ReceivableDate = DateTime.Now,
                PaymentTypeList = MVCHelperExtensions.ToSelectList(paymentTypes, Guid.Empty)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> QuotePayment(ReceivableViewModel model)
        {
            if (ModelState.IsValid)
            {
                var receivable = _mapper.Map<ReceivableViewModel, Receivable>(model);
                var quoteId = model.QuoteId;

                var quote = await _unitOfWork.Quotes.GetById(quoteId);

                receivable.Id = Guid.NewGuid();
                receivable.DateAdded = DateTime.Now;
                await _unitOfWork.Receivables.Add(receivable);

                ReceivableQuote receivableQuote = new()
                {
                    QuoteId = quoteId,
                    ReceivableId = receivable.Id
                };
                await _unitOfWork.ReceivableQuotes.AddAsync(receivableQuote);

                quote.IsPaid = true;
                _unitOfWork.Quotes.Update(quoteId, quote);
                await _unitOfWork.CompleteAsync();

                return RedirectToAction("Details", "Quotes", new { id = model.QuoteId });
            }

            var paymentTypes = await _unitOfWork.PaymentTypes.GetAll(r => r.OrderBy(n => n.Name));
            model.PaymentTypeList = MVCHelperExtensions.ToSelectList(paymentTypes, model.PaymentTypeId);
            return View(model);
        }

    }
}
