using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly IPolicyService _policyService;
        private readonly IQuoteService _quoteService;
        private IPolicyStatusService _policyStatusService;
        private IPolicyTypeService _policyTypeService;
        private ISalesTypeService _salesTypeService;
        private IPaymentMethodService _paymentMethodService;

        public PoliciesController(IPolicyService policyService,
                                    IQuoteService quoteService,
                                    IPolicyStatusService policyStatusService,
                                    IPolicyTypeService policyTypeService,
                                    ISalesTypeService salesTypeService,
                                    IPaymentMethodService paymentMethodService)
        {
            _policyService = policyService;
            _quoteService = quoteService;
            _policyStatusService = policyStatusService;
            _policyTypeService = policyTypeService;
            _salesTypeService = salesTypeService;
            _paymentMethodService = paymentMethodService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> QuoteToPolicy(Guid quoteId)
        {
            var paymentMethods = await _paymentMethodService.GetAllAsync();
            var policyStatuses = await _policyStatusService.GetAllAsync();
            var policyTypes = await _policyTypeService.GetAllAsync();
            var salesTypes = await _salesTypeService.GetAllAsync();

            PolicySaveResource resource = new()
            {
                QuoteId = quoteId,
                PaymentMethodList = new SelectList(paymentMethods, "Id", "Name", Guid.Empty),
                PolicyStatusList = new SelectList(policyStatuses, "Id", "Name", Guid.Empty),
                PolicyTypeList = new SelectList(policyTypes, "Id", "Name", Guid.Empty),
                SalesTypeList = new SelectList(salesTypes, "Id", "Name", Guid.Empty)
            };
            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> QuoteToPolicy(PolicySaveResource resource)
        {
            if (ModelState.IsValid)
            {
                QuoteResource quoteResource = await _quoteService.GetFirstOrDefaultAsync(resource.QuoteId);

                List<QuoteItemResource> quoteItemResources = new();
                foreach (var item in quoteResource.QuoteItems)
                {
                    QuoteItemResource quoteItemResource = new()
                    {
                        Id = item.Id,
                        QuoteId = item.QuoteId,
                        ClientRiskId = item.ClientRiskId,
                        CoverTypeId = item.CoverTypeId,
                        Description = item.Description,
                        SumInsured = item.SumInsured,
                        Premium = item.Premium,
                        Excess = item.Excess
                    };
                    quoteItemResources.Add(quoteItemResource);
                }

                resource.InceptionDate = resource.CoverStartDate;

                QuotePolicyObjectResource quotePolicyObjectResource = new()
                {
                    Quote = quoteResource,
                    Policy = resource,
                };

                quotePolicyObjectResource.QuoteItems = quoteItemResources;

                await _policyService.QuoteToPolicy(quotePolicyObjectResource);

                return RedirectToAction("Details", "Quotes", new { Id = resource.QuoteId});
            }

            var paymentMethods = await _paymentMethodService.GetAllAsync();
            var policyStatuses = await _policyStatusService.GetAllAsync();
            var policyTypes = await _policyTypeService.GetAllAsync();
            var salesTypes = await _salesTypeService.GetAllAsync();

            resource.PaymentMethodList = new SelectList(paymentMethods, "Id", "Name", resource.PaymentMethodId);
            resource.PolicyStatusList = new SelectList(policyStatuses, "Id", "Name", resource.PolicyStatusId);
            resource.PolicyTypeList = new SelectList(policyTypes, "Id", "Name", resource.PolicyTypeId);
            resource.SalesTypeList = new SelectList(salesTypes, "Id", "Name", resource.SalesTypeId);

            return View(resource);
        }
    }
}
