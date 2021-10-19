using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
            var quote = await _quoteService.GetByIdAsync(quoteId);
            var paymentMethods = await _paymentMethodService.GetAllAsync();
            var policyStatuses = await _policyStatusService.GetAllAsync();
            var policyTypes = await _policyTypeService.GetAllAsync();
            var salesTypes = await _salesTypeService.GetAllAsync();

            //var FullName = String.IsNullOrEmpty(quote.Client.FirstName) ? quote.Client.LastName : 
            //                quote.Client.FirstName + " " + 
            //                quote.Client.LastName;

            PolicySaveResource resource = new()
            {
                QuoteId = quoteId,
                InsurerPolicyNumber = "TBA",
                CoverStartDate = DateTime.Now,
                QuoteNumber = quote.QuoteNumber,

                RunDay = quote.RunDay,
                DayList = SelectLists.RegisteredDays(quote.RunDay),
                PaymentMethodList = SelectLists.PaymentMethods(paymentMethods, Guid.Empty),
                PolicyStatusList = SelectLists.PolicyStatuses(policyStatuses, Guid.Empty),
                PolicyTypeList = SelectLists.PolicyTypes(policyTypes, Guid.Empty),
                SalesTypeList = SelectLists.SalesTypes(salesTypes, Guid.Empty)
            };
            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> QuoteToPolicy(PolicySaveResource resource)
        {
            if (ModelState.IsValid)
            {
                QuoteResource quoteResource = await _quoteService.GetByIdAsync(resource.QuoteId);

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
                resource.RunDay = quoteResource.RunDay;

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

            resource.PaymentMethodList = SelectLists.PaymentMethods(paymentMethods, resource.PaymentMethodId);
            resource.PolicyStatusList = SelectLists.PolicyStatuses(policyStatuses, resource.PolicyStatusId);
            resource.PolicyTypeList = SelectLists.PolicyTypes(policyTypes, resource.PolicyTypeId);
            resource.SalesTypeList = SelectLists.SalesTypes(salesTypes, resource.SalesTypeId);

            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var portfolioClient = await _portfolioClientService.GetByIdAsync(portfolioClientId);
            var clientId = portfolioClient.ClientId;

            var bodyTypes = await _bodyTypeService.GetAllAsync();
            var driverTypes = await _driverTypeService.GetAllAsync();
            var houseConditions = await _houseConditionService.GetAllAsync();
            var motorMakes = await _motorMakeService.GetAllAsync();
            
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
                InsurerPolicyNumber = "TBA",
                CoverStartDate = DateTime.Now,
                InsurerList = SelectLists.Insurers(insurers, Guid.Empty),
                PaymentMethodList = SelectLists.PaymentMethods(paymentMethods, Guid.Empty),
                PolicyStatusList = SelectLists.PolicyStatuses(policyStatuses, Guid.Empty),
                PolicyTypeList = SelectLists.PolicyTypes(policyTypes, Guid.Empty),
                SalesTypeList = SelectLists.SalesTypes(salesTypes, Guid.Empty),

                CoverTypeList = SelectLists.CoverTypes(coverTypes, Guid.Empty),
                DateRangeList = SelectLists.RegisteredYears(0),
                BodyTypeList = SelectLists.BodyTypes(bodyTypes, Guid.Empty),
                DriverTypeList = SelectLists.DriverTypes(driverTypes, Guid.Empty),
                HouseConditionList = SelectLists.HouseConditions(houseConditions, Guid.Empty),
                MotorMakeList = SelectLists.MotorMakes(motorMakes, Guid.Empty),
                
                ResidenceTypeList = SelectLists.ResidenceTypes(residenceTypes, Guid.Empty),
                ResidenceUseList = SelectLists.ResidenceUses(residenceUses, Guid.Empty),
                RoofTypeList = SelectLists.RoofTypes(roofTypes, Guid.Empty),
                WallTypeList = SelectLists.WallTypes(wallTypes, Guid.Empty)
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
            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostPolicy(PolicyObjectResource policyObject)
        {
            if (policyObject == null)
            {
                throw new ArgumentNullException(nameof(policyObject));
            };

            await _policyService.AddAsync(policyObject);

            return Ok(new
                    {
                        policyObject.Policy.Id,
                        policyObject.Policy.PortfolioClientId,
                        policyObject.Policy.PolicyNumber
                    });
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
