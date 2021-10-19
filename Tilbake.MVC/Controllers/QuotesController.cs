using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class QuotesController : Controller
    {
        private readonly IQuoteService _quoteService;
        private readonly IBuildingConditionService _buildingConditionService;
        private readonly ICountryService _countryService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IInsurerService _insurerService;
        private readonly IInsurerBranchService _insurerBranchService;
        private readonly ISalesTypeService _salesTypeService;
        private readonly IPolicyTypeService _policyTypeService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IQuoteStatusService _quoteStatusService;
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
        private readonly IPortfolioService _portfolioService;
        private readonly ITaxService _taxService;
        private readonly ITitleService _titleService;

        public QuotesController(IQuoteService quoteService,
                                IBuildingConditionService buildingConditionService,
                                ICountryService countryService,
                                ICoverTypeService coverTypeService,
                                IInsurerService insurerService,
                                IInsurerBranchService insurerBranchService,
                                ISalesTypeService salesTypeService,
                                IPolicyTypeService policyTypeService,
                                IPaymentMethodService paymentMethodService,
                                IQuoteStatusService quoteStatusService,
                                IBodyTypeService bodyTypeService,
                                IDriverTypeService driverTypeService,
                                IHouseConditionService houseConditionService,
                                IMotorMakeService motorMakeService,
                                IMotorModelService motorModelService,
                                IResidenceTypeService residenceTypeService,
                                IResidenceUseService residenceUseService,
                                IRoofTypeService roofTypeService,
                                IWallTypeService wallTypeService,
                                IPortfolioClientService portfolioClientService,
                                IPortfolioService portfolioService,
                                ITaxService taxService,
                                ITitleService titleService)
        {
            _quoteService = quoteService;
            _buildingConditionService = buildingConditionService;
            _coverTypeService = coverTypeService;
            _countryService = countryService;
            _insurerService = insurerService;
            _insurerBranchService = insurerBranchService;
            _salesTypeService = salesTypeService;
            _policyTypeService = policyTypeService;
            _paymentMethodService = paymentMethodService;
            _quoteStatusService = quoteStatusService;
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
            _portfolioService = portfolioService;
            _taxService = taxService;
            _titleService = titleService;
        }

        // GET: Quotes
        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var resources = await _quoteService.GetByPortfolioAsync(portfolioId);
            return View(resources);
        }

        public async Task<IActionResult> PortfolioClientQuotes(Guid portfolioClientId)
        {
            var resources = await _quoteService.GetByPortfolioClientAsync(portfolioClientId);
            var portfolioClient = await _portfolioClientService.GetByIdAsync(portfolioClientId);
            
            ViewBag.PortfolioClientId = portfolioClientId;
            ViewBag.ClientId = portfolioClient.ClientId;
            ViewBag.PortfolioId = portfolioClient.PortfolioId;
            ViewBag.Client = portfolioClient.Client;
            ViewBag.PortfolioName = portfolioClient.Portfolio.Name;
            return View(resources);
        }

        public async Task<IActionResult> Search(Guid portfolioId, string searchString = "~#")
        {
            var resource = await _portfolioService.GetByIdAsync(portfolioId);
            var resources = await _quoteService.GetByPortfolioAsync(portfolioId);

            if (!String.IsNullOrEmpty(searchString))
            {
                var isNumeric = int.TryParse(searchString, out int quoteNumber);
                if (isNumeric)
                {
                    resources = resources.Where(r => r.QuoteNumber.Equals(quoteNumber));
                } else
                {
                    resources = resources.Where(r => r.Client.LastName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                            //|| r.Client.FirstName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                            || r.Client.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                }
            }
            
            QuoteSearchResource searchResource = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = resource.Name,
                SearchString = "",
                QuoteResources = resources.ToList()
            };
            return View(searchResource);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var taxes = await _taxService.GetAllAsync();
            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            var resource = await _quoteService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            var portfolioClient = await _portfolioClientService.GetByIdAsync(resource.PortfolioClientId);
            
            resource.PortfolioId = portfolioClient.PortfolioId;
            resource.PortfolioName = portfolioClient.Portfolio.Name;            
            resource.TaxRate = taxRate;
            return View(resource);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostQuote(QuoteObjectResource quoteObject)
        {
            if (quoteObject == null)
            {
                throw new ArgumentNullException(nameof(quoteObject));
            };

            await _quoteService.AddAsync(quoteObject);

            return Json(new { quoteObject.ClientId });
        }

        // GET: Quotes/Create
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var portfolioClient = await _portfolioClientService.GetByIdAsync(portfolioClientId);

            var clientId = portfolioClient.ClientId;
            var portfolioId = portfolioClient.PortfolioId;
            var client = portfolioClient.Client;
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            var bodyTypes = await _bodyTypeService.GetAllAsync();
            var buildingConditions = await _buildingConditionService.GetAllAsync();
            var driverTypes = await _driverTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var houseConditions = await _houseConditionService.GetAllAsync();
            var motorMakes = await _motorMakeService.GetAllAsync();
            var motorMakeId = motorMakes.FirstOrDefault().Id;
            var motorModels = await _motorModelService.GetByMotorMakeIdAsync(motorMakeId);
            var residenceTypes = await _residenceTypeService.GetAllAsync();
            var residenceUses = await _residenceUseService.GetAllAsync();
            var roofTypes = await _roofTypeService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();
            var wallTypes = await _wallTypeService.GetAllAsync();

            var coverTypes = await _coverTypeService.GetAllAsync();
            var quoteStatuses = await _quoteStatusService.GetAllAsync();

            QuoteSaveResource resource = new()
            {
                PortfolioClientId = portfolioClientId,
                ClientId = clientId,
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                Client = client,
                BuildingConditionList = SelectLists.BuildingConditions(buildingConditions, Guid.Empty),
                CoverTypeList = SelectLists.CoverTypes(coverTypes, Guid.Empty),
                QuoteStatusList = SelectLists.QuoteStatuses(quoteStatuses, Guid.Empty),
                BodyTypeList = SelectLists.BodyTypes(bodyTypes, Guid.Empty),
                CountryList = SelectLists.Countries(countries, Guid.Empty),
                DayList = SelectLists.RegisteredDays(0),
                DriverTypeList = SelectLists.DriverTypes(driverTypes, Guid.Empty),
                HouseConditionList = SelectLists.HouseConditions(houseConditions, Guid.Empty),
                MotorMakeList = SelectLists.MotorMakes(motorMakes, Guid.Empty),
                MotorModelList = SelectLists.MotorModels(motorModels, Guid.Empty),
                ResidenceTypeList = SelectLists.ResidenceTypes(residenceTypes, Guid.Empty),
                ResidenceUseList = SelectLists.ResidenceUses(residenceUses, Guid.Empty),
                RoofTypeList = SelectLists.RoofTypes(roofTypes, Guid.Empty),
                WallTypeList = SelectLists.WallTypes(wallTypes, Guid.Empty),
                TitleList = SelectLists.Titles(titles, Guid.Empty),
                DateRangeList = SelectLists.RegisteredYears(0)
            };
            return View(resource);
        }

        // POST: Quotes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuoteObjectResource resource)
        {
            if (ModelState.IsValid)
            {
                await _quoteService.AddAsync(resource);
                return RedirectToAction("PortfolioClientQuotes", "Quotes", new { resource.Quote.PortfolioClientId });
            }

            return View(resource);
        }

        public async Task<IActionResult> Quotation(Guid id)
        {
            var taxes = await _taxService.GetAllAsync();
            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            ViewBag.TaxRate = taxRate;
            var resource = await _quoteService.GetByIdAsync(id);
            return View(resource);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var taxes = await _taxService.GetAllAsync();
            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            var resource = await _quoteService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            var insurerBranchId = resource.InsurerBranchId;

            var insurerBranch = await _insurerBranchService.GetByIdAsync(insurerBranchId);
            var insurerId = Guid.Empty;

            if(insurerBranch != null)
            {
                insurerId = insurerBranch.InsurerId;
            }

            var portfolioClient = await _portfolioClientService.GetByIdAsync(resource.PortfolioClientId);
            
            var quoteStatuses = await _quoteStatusService.GetAllAsync();
            var insurers = await _insurerService.GetAllAsync();
            var salesTypes = await _salesTypeService.GetAllAsync();
            var policyTypes = await _policyTypeService.GetAllAsync();
            var paymentMethods = await _paymentMethodService.GetAllAsync();
            var insurerBranches = await _insurerBranchService.GetByInsurerIdAsync(insurerId);

            resource.ClientId = portfolioClient.ClientId;
            resource.PortfolioId = portfolioClient.PortfolioId;
            resource.PortfolioName = portfolioClient.Portfolio.Name;
            resource.InsurerId = insurerId;
            resource.TaxRate = taxRate;
            resource.DayList = SelectLists.RegisteredDays(resource.RunDay);
            resource.QuoteStatusList = SelectLists.QuoteStatuses(quoteStatuses, resource.QuoteStatusId);
            resource.SalesTypeList = SelectLists.SalesTypes(salesTypes, resource.SalesTypeId);
            resource.PolicyTypeList = SelectLists.PolicyTypes(policyTypes, resource.PolicyTypeId);
            resource.PaymentMethodList = SelectLists.PaymentMethods(paymentMethods, resource.PaymentMethodId);
            resource.InsurerList = SelectLists.Insurers(insurers, insurerId);
            resource.InsurerBranchList = SelectLists.InsurerBranches(insurerBranches, insurerBranchId);

            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, QuoteResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _quoteService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Details), new { id = resource.Id });
            }

            var quoteStatuses = await _quoteStatusService.GetAllAsync();
            var insurers = await _insurerService.GetAllAsync();
            var insurerBranches = await _insurerBranchService.GetByInsurerIdAsync(resource.InsurerId);
            var salesTypes = await _salesTypeService.GetAllAsync();
            var policyTypes = await _policyTypeService.GetAllAsync();
            var paymentMethods = await _paymentMethodService.GetAllAsync();

            resource.QuoteStatusList = SelectLists.QuoteStatuses(quoteStatuses, resource.QuoteStatusId);
            resource.SalesTypeList = SelectLists.SalesTypes(salesTypes, resource.SalesTypeId);
            resource.PolicyTypeList = SelectLists.PolicyTypes(policyTypes, resource.PolicyTypeId);
            resource.PaymentMethodList = SelectLists.PaymentMethods(paymentMethods, resource.PaymentMethodId);
            resource.InsurerList = SelectLists.Insurers(insurers, resource.InsurerId);
            resource.InsurerBranchList = SelectLists.InsurerBranches(insurerBranches, resource.InsurerBranchId);
            return View(resource);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var resource = await _quoteService.GetByIdAsync(id);
            await _quoteService.DeleteAsync(resource);

            return RedirectToAction(nameof(Details), "PortfolioClients", new { resource.PortfolioClientId });
        }
    }
}
