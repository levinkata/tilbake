using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

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
            var ViewModels = await _quoteService.GetByPortfolioAsync(portfolioId);
            return View(ViewModels);
        }

        public async Task<IActionResult> PortfolioClientQuotes(Guid portfolioClientId)
        {
            var ViewModels = await _quoteService.GetByPortfolioClientAsync(portfolioClientId);
            var portfolioClient = await _portfolioClientService.GetByIdAsync(portfolioClientId);
            
            ViewBag.PortfolioClientId = portfolioClientId;
            ViewBag.ClientId = portfolioClient.ClientId;
            ViewBag.PortfolioId = portfolioClient.PortfolioId;
            ViewBag.Client = portfolioClient.Client;
            ViewBag.PortfolioName = portfolioClient.Portfolio.Name;
            return View(ViewModels);
        }

        public async Task<IActionResult> Search(Guid portfolioId, string searchString = "~#")
        {
            var ViewModel = await _portfolioService.GetByIdAsync(portfolioId);
            var ViewModels = await _quoteService.GetByPortfolioAsync(portfolioId);

            if (!String.IsNullOrEmpty(searchString))
            {
                var isNumeric = int.TryParse(searchString, out int quoteNumber);
                if (isNumeric)
                {
                    ViewModels = ViewModels.Where(r => r.QuoteNumber.Equals(quoteNumber));
                } else
                {
                    ViewModels = ViewModels.Where(r => r.Client.LastName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                            //|| r.Client.FirstName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                            || r.Client.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                }
            }
            
            QuoteSearchViewModel searchViewModel = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = ViewModel.Name,
                SearchString = "",
                QuoteViewModels = ViewModels.ToList()
            };
            return View(searchViewModel);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var taxes = await _taxService.GetAllAsync();
            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            var ViewModel = await _quoteService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            var portfolioClient = await _portfolioClientService.GetByIdAsync(ViewModel.PortfolioClientId);
            
            ViewModel.PortfolioId = portfolioClient.PortfolioId;
            ViewModel.PortfolioName = portfolioClient.Portfolio.Name;            
            ViewModel.TaxRate = taxRate;
            return View(ViewModel);
        }
        
        [HttpPost]
        public IActionResult PostQuote(QuoteObjectViewModel quoteObject)
        {
            if (quoteObject == null)
            {
                throw new ArgumentNullException(nameof(quoteObject));
            };

            _quoteService.AddAsync(quoteObject);

            return Json(new { quoteObject.ClientId });
        }

        // GET: Quotes/Create
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var branchName = "No Insurer Branch";
            var portfolioClient = await _portfolioClientService.GetByIdAsync(portfolioClientId);
            var clientId = portfolioClient.ClientId;
            var portfolioId = portfolioClient.PortfolioId;
            var client = portfolioClient.Client;
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);
            var insurerBranch = await _insurerBranchService.GetByNameAsync(branchName);

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

            QuoteViewModel ViewModel = new()
            {
                PortfolioClientId = portfolioClientId,
                ClientId = clientId,
                PortfolioId = portfolioId,
                InsurerBranchId = insurerBranch.Id,
                PortfolioName = portfolio.Name,
                Client = client,
                QuoteDate = DateTime.Now.Date,
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
            return View(ViewModel);
        }

        // POST: Quotes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QuoteObjectViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _quoteService.AddAsync(ViewModel);
                return RedirectToAction("PortfolioClientQuotes", "Quotes", new { ViewModel.Quote.PortfolioClientId });
            }

            return View(ViewModel);
        }

        public async Task<IActionResult> Quotation(Guid id)
        {
            var taxes = await _taxService.GetAllAsync();
            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            ViewBag.TaxRate = taxRate;
            var ViewModel = await _quoteService.GetByIdAsync(id);
            return View(ViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var taxes = await _taxService.GetAllAsync();
            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            var ViewModel = await _quoteService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            var insurerBranchId = ViewModel.InsurerBranchId;

            var insurerBranch = await _insurerBranchService.GetByIdAsync(insurerBranchId);
            var insurerId = Guid.Empty;

            if(insurerBranch != null)
            {
                insurerId = insurerBranch.InsurerId;
            }

            var portfolioClient = await _portfolioClientService.GetByIdAsync(ViewModel.PortfolioClientId);
            
            var quoteStatuses = await _quoteStatusService.GetAllAsync();
            var insurers = await _insurerService.GetAllAsync();
            var salesTypes = await _salesTypeService.GetAllAsync();
            var policyTypes = await _policyTypeService.GetAllAsync();
            var paymentMethods = await _paymentMethodService.GetAllAsync();
            var insurerBranches = await _insurerBranchService.GetByInsurerIdAsync(insurerId);

            ViewModel.ClientId = portfolioClient.ClientId;
            ViewModel.PortfolioId = portfolioClient.PortfolioId;
            ViewModel.PortfolioName = portfolioClient.Portfolio.Name;
            ViewModel.InsurerId = insurerId;
            ViewModel.TaxRate = taxRate;
            ViewModel.DayList = SelectLists.RegisteredDays(ViewModel.RunDay);
            ViewModel.QuoteStatusList = SelectLists.QuoteStatuses(quoteStatuses, ViewModel.QuoteStatusId);
            ViewModel.SalesTypeList = SelectLists.SalesTypes(salesTypes, ViewModel.SalesTypeId);
            ViewModel.PolicyTypeList = SelectLists.PolicyTypes(policyTypes, ViewModel.PolicyTypeId);
            ViewModel.PaymentMethodList = SelectLists.PaymentMethods(paymentMethods, ViewModel.PaymentMethodId);
            ViewModel.InsurerList = SelectLists.Insurers(insurers, insurerId);
            ViewModel.InsurerBranchList = SelectLists.InsurerBranches(insurerBranches, insurerBranchId);

            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, QuoteViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _quoteService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Details), new { id = ViewModel.Id });
            }

            var quoteStatuses = await _quoteStatusService.GetAllAsync();
            var insurers = await _insurerService.GetAllAsync();
            var insurerBranches = await _insurerBranchService.GetByInsurerIdAsync(ViewModel.InsurerId);
            var salesTypes = await _salesTypeService.GetAllAsync();
            var policyTypes = await _policyTypeService.GetAllAsync();
            var paymentMethods = await _paymentMethodService.GetAllAsync();

            ViewModel.QuoteStatusList = SelectLists.QuoteStatuses(quoteStatuses, ViewModel.QuoteStatusId);
            ViewModel.SalesTypeList = SelectLists.SalesTypes(salesTypes, ViewModel.SalesTypeId);
            ViewModel.PolicyTypeList = SelectLists.PolicyTypes(policyTypes, ViewModel.PolicyTypeId);
            ViewModel.PaymentMethodList = SelectLists.PaymentMethods(paymentMethods, ViewModel.PaymentMethodId);
            ViewModel.InsurerList = SelectLists.Insurers(insurers, ViewModel.InsurerId);
            ViewModel.InsurerBranchList = SelectLists.InsurerBranches(insurerBranches, ViewModel.InsurerBranchId);
            return View(ViewModel);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _quoteService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ViewModel = await _quoteService.GetByIdAsync(id);
            await _quoteService.DeleteAsync(id);

            return RedirectToAction(nameof(Details), "PortfolioClients", new { ViewModel.PortfolioClientId });
        }
    }
}
