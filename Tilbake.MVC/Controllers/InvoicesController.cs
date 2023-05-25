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
    public class InvoicesController : BaseController
    {
        public InvoicesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Invoices.GetAll(r => r.OrderBy(n => n.InvoiceNumber));
            var model = _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid policyId)
        {
            var policyRisks = await _unitOfWork.PolicyRisks.GetByPolicyId(policyId);
            
            var invoiceStatuses = await _unitOfWork.InvoiceStatuses.GetAll();
            var taxes = await _unitOfWork.Taxes.GetAll();

            InvoiceViewModel model = new()
            {
                PolicyId = policyId,
                Amount = policyRisks.Sum(r => r.Premium),
                InvoiceStatusList = MVCHelperExtensions.ToSelectList(invoiceStatuses, Guid.Empty)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var policyId = model.PolicyId;
                var policyRisks = await _unitOfWork.PolicyRisks.Get(r => r.PolicyId == policyId);

                var invoice = _mapper.Map<InvoiceViewModel, Invoice>(model);

                var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
                var taxRate = taxes.Take(1).Select(r => r.TaxRate).FirstOrDefault();

                invoice.Id = Guid.NewGuid();
                invoice.Amount = policyRisks.Sum(r => r.Premium);
                //invoice.TaxRate = taxRate;
                invoice.TaxAmount = invoice.Amount * taxRate / 100;
                invoice.ReducingBalance = invoice.Amount;
                invoice.DateAdded = DateTime.Now;
                await _unitOfWork.Invoices.AddAsync(invoice);

                var invoiceId = invoice.Id;

                List<InvoiceItem> invoiceItems = new();
                foreach (var item in policyRisks)
                {
                    InvoiceItem invoiceItem = new()
                    {
                        Id = Guid.NewGuid(),
                        InvoiceId = invoiceId,
                        PolicyRiskId = item.Id
                    };
                    invoiceItems.Add(invoiceItem);
                }
                _unitOfWork.InvoiceItems.AddRange(invoiceItems);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Details", "Policies", new { id = model.PolicyId });
            }

            var invoiceStatuses = await _unitOfWork.InvoiceStatuses.GetAll();
            model.InvoiceStatusList = MVCHelperExtensions.ToSelectList(invoiceStatuses, model.InvoiceStatusId);
            return View(model);
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Invoices.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Invoice, InvoiceViewModel>(result);
            return View(model);
        }

        public IActionResult Invoice()
        {
            return View();
        }
    }
}