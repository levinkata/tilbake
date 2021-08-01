using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly IPolicyService _policyService;
        private readonly IQuoteService _quoteService;
        private readonly IInsurerService _insurerService;
        private readonly IPolicyStatusService _policyStatusService;
        private readonly IPolicyTypeService _policyTypeService;
        private readonly ISalesTypeService _salesTypeService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IDriverTypeService _driverTypeService;
        private readonly IHouseConditionService _houseConditionService;
        private readonly IMotorMakeService _motorMakeService;
        private readonly IMotorModelService _motorModelService;
        private readonly IMotorUseService _motorUseService;
        private readonly IResidenceTypeService _residenceTypeService;
        private readonly IResidenceUseService _residenceUseService;
        private readonly IRoofTypeService _roofTypeService;
        private readonly IWallTypeService _wallTypeService;
        private readonly IPortfolioClientService _portfolioClientService;

        public PoliciesController(IPolicyService policyService,
                                    IQuoteService quoteService,
                                    ICoverTypeService coverTypeService,
                                    IInsurerService insurerService,
                                    IPolicyStatusService policyStatusService,
                                    IPolicyTypeService policyTypeService,
                                    ISalesTypeService salesTypeService,
                                    IPaymentMethodService paymentMethodService,                  
                                    IBodyTypeService bodyTypeService,
                                    IDriverTypeService driverTypeService,
                                    IHouseConditionService houseConditionService,
                                    IMotorMakeService motorMakeService,
                                    IMotorModelService motorModelService,
                                    IMotorUseService motorUseService,
                                    IResidenceTypeService residenceTypeService,
                                    IResidenceUseService residenceUseService,
                                    IRoofTypeService roofTypeService,
                                    IWallTypeService wallTypeService,
                                    IPortfolioClientService portfolioClientService)
        {
            _policyService = policyService;
            _quoteService = quoteService;
            _insurerService = insurerService;
            _coverTypeService = coverTypeService;
            _policyStatusService = policyStatusService;
            _policyTypeService = policyTypeService;
            _salesTypeService = salesTypeService;
            _paymentMethodService = paymentMethodService;
            _bodyTypeService = bodyTypeService;
            _driverTypeService = driverTypeService;
            _houseConditionService = houseConditionService;
            _motorMakeService = motorMakeService;
            _motorModelService = motorModelService;
            _motorUseService = motorUseService;
            _residenceTypeService = residenceTypeService;
            _residenceUseService = residenceUseService;
            _roofTypeService = roofTypeService;
            _wallTypeService = wallTypeService;
            _portfolioClientService = portfolioClientService;
        }

        public async Task<IActionResult> Index(Guid portfolioClientId)
        {
            var resources = await _policyService.GetByPorfolioClientIdAsync(portfolioClientId);
            return View(resources);
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

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var portfolioClient = await _portfolioClientService.FindAsync(portfolioClientId);
            var clientId = portfolioClient.ClientId;

            var bodyTypes = await _bodyTypeService.GetAllAsync();
            var driverTypes = await _driverTypeService.GetAllAsync();
            var houseConditions = await _houseConditionService.GetAllAsync();
            var motorMakes = await _motorMakeService.GetAllAsync();
            
            
            var motorUses = await _motorUseService.GetAllAsync();
            var residenceTypes = await _residenceTypeService.GetAllAsync();
            var residenceUses = await _residenceUseService.GetAllAsync();
            var roofTypes = await _roofTypeService.GetAllAsync();
            var wallTypes = await _wallTypeService.GetAllAsync();

            var coverTypes = await _coverTypeService.GetAllAsync();
            var insurers = await _insurerService.GetAllAsync();
            var paymentMethods = await _paymentMethodService.GetAllAsync();
            var policyStatuses = await _policyStatusService.GetAllAsync();
            var policyTypes = await _policyTypeService.GetAllAsync();
            var salesTypes = await _salesTypeService.GetAllAsync();

            PolicySaveResource resource = new()
            {
                PortfolioClientId = portfolioClientId,
                ClientId = clientId,
                InsurerList = new SelectList(insurers, "Id", "Name", Guid.Empty),
                PaymentMethodList = new SelectList(paymentMethods, "Id", "Name", Guid.Empty),
                PolicyStatusList = new SelectList(policyStatuses, "Id", "Name", Guid.Empty),
                PolicyTypeList = new SelectList(policyTypes, "Id", "Name", Guid.Empty),
                SalesTypeList = new SelectList(salesTypes, "Id", "Name", Guid.Empty),

                CoverTypeList = new SelectList(coverTypes, "Id", "Name"),
                DateRangeList = new SelectList(DateRanges.Years(), "Value", "Text"),
                BodyTypeList = new SelectList(bodyTypes, "Id", "Name"),
                DriverTypeList = new SelectList(driverTypes, "Id", "Name"),
                HouseConditionList = new SelectList(houseConditions, "Id", "Name"),
                MotorMakeList = new SelectList(motorMakes, "Id", "Name"),
                
                MotorUseList = new SelectList(motorUses, "Id", "Name"),
                ResidenceTypeList = new SelectList(residenceTypes, "Id", "Name"),
                ResidenceUseList = new SelectList(residenceUses, "Id", "Name"),
                RoofTypeList = new SelectList(roofTypes, "Id", "Name"),
                WallTypeList = new SelectList(wallTypes, "Id", "Name")
            };

            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PolicyObjectResource resource)
        {
            if (ModelState.IsValid)
            {
                await _policyService.AddAsync(resource);
                return RedirectToAction(nameof(Index), new { portfolioClientId = resource.Policy.PortfolioClientId });
            }
            return await Task.Run(() => View(resource));
        }

        [HttpPost]
        public async Task<IActionResult> PostPolicy(PolicyObjectResource policyObject)
        {
            if (policyObject == null)
            {
                throw new ArgumentNullException(nameof(policyObject));
            };

            var portfolioClientId = policyObject.Policy.PortfolioClientId;

            await _policyService.AddAsync(policyObject);

            return await Task.Run(() => Ok(new
            {
                policyObject.Policy.Id,
                policyObject.Policy.PortfolioClientId,
                policyObject.Policy.PolicyNumber
            }));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var resource = await _policyService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }
    }
}
