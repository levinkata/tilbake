using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IPolicyRiskService _policyRiskService;
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceStatusService _invoiceStatusService;
        private readonly ITaxService _taxService;

        public InvoicesController(IPolicyRiskService policyRiskService,
                                    IInvoiceService invoiceService,
                                    IInvoiceStatusService invoiceStatusService,
                                    ITaxService taxService)
        {
            _invoiceStatusService = invoiceStatusService;
            _taxService = taxService;
            _policyRiskService = policyRiskService;
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ViewModels = await _invoiceService.GetAllAsync();

            return View(ViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid policyId)
        {
            var policyRisks = await _policyRiskService.GetByPolicyIdAsync(policyId);
            
            var invoiceStatuses = await _invoiceStatusService.GetAllAsync();
            var taxes = await _taxService.GetAllAsync();

            InvoiceViewModel ViewModel = new()
            {
                PolicyId = policyId,
                Amount = policyRisks.Sum(r => r.Premium),
                InvoiceStatusList = SelectLists.InvoiceStatuses(invoiceStatuses, Guid.Empty),
                TaxList = SelectLists.Taxes(taxes, Guid.Empty)
            };
            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult Create(InvoiceViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _invoiceService.AddAsync(ViewModel);
                return RedirectToAction("Details", "Policies", new { id = ViewModel.PolicyId });
            }
            return View(ViewModel);
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var ViewModel = await _invoiceService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        public IActionResult Invoice()
        {
            return View();
        }
    }
}