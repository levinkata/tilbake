using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Helpers;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class QuotesController : BaseController
    {
        public QuotesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Quotes
        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var result = await _unitOfWork.Quotes.GetAll(r => r.OrderBy(n => n.QuoteNumber));
            var model = _mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteViewModel>>(result);
            return View(model);
        }

        public async Task<IActionResult> PortfolioClientQuotes(Guid portfolioClientId)
        {
            var result = await _unitOfWork.Quotes.GetByPortfolioClientId(portfolioClientId);
            var model = _mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteViewModel>>(result);
            var portfolioClient = await _unitOfWork.PortfolioClients.GetById(portfolioClientId);
            
            ViewBag.PortfolioClientId = portfolioClientId;
            ViewBag.ClientId = portfolioClient.ClientId;
            ViewBag.PortfolioId = portfolioClient.PortfolioId;
            ViewBag.Client = portfolioClient.Client;
            ViewBag.PortfolioName = portfolioClient.Portfolio.Name;
            return View(model);
        }

        public async Task<IActionResult> Search(Guid portfolioId, string searchString = "~#")
        {
            var portfolio = await _unitOfWork.Portfolios.GetByIdAsync(portfolioId);
            var result = await _unitOfWork.Quotes.GetByPortfolioId(portfolioId);
            var model = _mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteViewModel>>(result);

            if (!String.IsNullOrEmpty(searchString))
            {
                var isNumeric = int.TryParse(searchString, out int quoteNumber);
                if (isNumeric)
                {
                    model = model.Where(r => r.QuoteNumber.Equals(quoteNumber));
                } else
                {
                    model = model.Where(r => r.Client.LastName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                            || r.Client.FirstName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                            || r.Client.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                }
            }
            
            QuoteSearchViewModel searchViewModel = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                SearchString = "",
                QuoteViewModels = model
            };
            return View(searchViewModel);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            var result = await _unitOfWork.Quotes.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<Quote, QuoteViewModel>(result);
            var portfolioClient = await _unitOfWork.PortfolioClients.GetById(model.PortfolioClientId);

            model.PortfolioId = portfolioClient.PortfolioId;
            model.PortfolioName = portfolioClient.Portfolio.Name;
            model.TaxRate = taxRate;
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostQuote(QuoteObjectViewModel quoteObject)
        {
            if (quoteObject == null)
            {
                throw new ArgumentNullException(nameof(quoteObject));
            };

            var modelQuoteItems = quoteObject.QuoteItems;
            if(modelQuoteItems != null)
            {
                var quoteItems = _mapper.Map<IEnumerable<QuoteItemViewModel>, IEnumerable<QuoteItem>>(modelQuoteItems);

                var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));

                var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

                var clientId = quoteObject.ClientId;

                var modelQuote = quoteObject.Quote;
                var quote = _mapper.Map<QuoteViewModel, Quote>(modelQuote);

                quote.Id = Guid.NewGuid();
                quote.QuoteDate = DateTime.Now;
                quote.DateAdded = DateTime.Now;

                await _unitOfWork.Quotes.Add(quote);
                var quoteId = quote.Id;

                //  AllRisk Unspecified
                if (quoteObject.AllRisks != null)
                {
                    if (quoteObject.RiskItems != null)
                    {
                        //  Create RiskItem Record
                        var modelRiskItems = quoteObject.RiskItems;
                        var riskItems = _mapper.Map<IEnumerable<RiskItemViewModel>, IEnumerable<RiskItem>>(modelRiskItems);
                        _unitOfWork.RiskItems.AddRange(riskItems);

                        //  Update QuoteItems with AllRiskId
                        var modelAllRisks = quoteObject.AllRisks;
                        var allRisks = _mapper.Map<IEnumerable<AllRiskViewModel>, IEnumerable<AllRisk>>(modelAllRisks);
                        _unitOfWork.AllRisks.AddRange(allRisks);

                        foreach (var allRisk in allRisks)
                        {
                            var allRiskId = allRisk.Id;

                            Risk risk = new()
                            {
                                Id = Guid.NewGuid(),
                                AllRiskId = allRiskId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.Risks.Add(risk);

                            var riskId = risk.Id;

                            ClientRisk clientRisk = new()
                            {
                                Id = Guid.NewGuid(),
                                ClientId = clientId,
                                RiskId = riskId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.ClientRisks.Add(clientRisk);

                            var clientRiskId = clientRisk.Id;

                            foreach (var item in quoteItems.Where(x => x.ClientRiskId == allRiskId))
                            {
                                item.QuoteId = quoteId;
                                item.ClientRiskId = clientRiskId;
                                item.DateAdded = DateTime.Now;
                                item.TaxRate = taxRate;
                                item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                            }
                        }
                    }
                }

                //  AllRisk Specified
                if (quoteObject.AllRiskSpecifieds != null)
                {
                    if (quoteObject.SpecifiedRiskItems != null)
                    {
                        //  Create RiskItem Record
                        var modelRiskItems = quoteObject.SpecifiedRiskItems;
                        var riskItems = _mapper.Map<IEnumerable<RiskItemViewModel>, IEnumerable<RiskItem>>(modelRiskItems);
                        _unitOfWork.RiskItems.AddRange(riskItems);

                        //  Update QuoteItems with AllRiskSpecifiedId
                        var modelAllRiskSpecifieds = quoteObject.AllRiskSpecifieds;
                        var allRiskSpecifieds = _mapper.Map<IEnumerable<AllRiskSpecifiedViewModel>, IEnumerable<AllRiskSpecified>>(modelAllRiskSpecifieds);
                        _unitOfWork.AllRiskSpecifieds.AddRange(allRiskSpecifieds);

                        foreach (var allRiskSpecified in allRiskSpecifieds)
                        {
                            var allRiskSpecifiedId = allRiskSpecified.Id;

                            Risk risk = new()
                            {
                                Id = Guid.NewGuid(),
                                AllRiskSpecifiedId = allRiskSpecifiedId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.Risks.Add(risk);

                            var riskId = risk.Id;

                            ClientRisk clientRisk = new()
                            {
                                Id = Guid.NewGuid(),
                                ClientId = clientId,
                                RiskId = riskId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.ClientRisks.Add(clientRisk);

                            var clientRiskId = clientRisk.Id;

                            foreach (var item in quoteItems.Where(x => x.ClientRiskId == allRiskSpecifiedId))
                            {
                                item.QuoteId = quoteId;
                                item.ClientRiskId = clientRiskId;
                                item.DateAdded = DateTime.Now;
                                item.TaxRate = taxRate;
                                item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                            }
                        }
                    }
                }

                //  Building
                if (quoteObject.Buildings != null)
                {
                    //  Update QuoteItems with BuildingId
                    var modelBuildings = quoteObject.Buildings;
                    var buildings = _mapper.Map<IEnumerable<BuildingViewModel>, IEnumerable<Building>>(modelBuildings);
                    _unitOfWork.Buildings.AddRange(buildings);

                    foreach (var building in buildings)
                    {
                        var buildingId = building.Id;

                        Risk risk = new()
                        {
                            Id = Guid.NewGuid(),
                            BuildingId = buildingId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.Risks.Add(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.ClientRisks.Add(clientRisk);

                        var clientRiskId = clientRisk.Id;

                        foreach (var item in quoteItems.Where(x => x.ClientRiskId == buildingId))
                        {
                            item.QuoteId = quoteId;
                            item.ClientRiskId = clientRiskId;
                            item.DateAdded = DateTime.Now;
                            item.TaxRate = taxRate;
                            item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                        }
                    }
                }

                //  Content
                if (quoteObject.Contents != null)
                {
                    //  Update QuoteItems with ContentId
                    var modelContents = quoteObject.Contents;
                    var contents = _mapper.Map<IEnumerable<ContentViewModel>, IEnumerable<Content>>(modelContents);
                    _unitOfWork.Contents.AddRange(contents);

                    foreach (var content in contents)
                    {
                        var contentId = content.Id;

                        Risk risk = new()
                        {
                            Id = Guid.NewGuid(),
                            ContentId = contentId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.Risks.Add(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.ClientRisks.Add(clientRisk);

                        var clientRiskId = clientRisk.Id;

                        foreach (var item in quoteItems.Where(x => x.ClientRiskId == contentId))
                        {
                            item.QuoteId = quoteId;
                            item.ClientRiskId = clientRiskId;
                            item.DateAdded = DateTime.Now;
                            item.TaxRate = taxRate;
                            item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                        }
                    }
                }

                //  ExcessBuyBack
                if (quoteObject.ExcessBuyBacks != null)
                {
                    //  Update QuoteItems with ExcessBuyBackId
                    var modelExcessBuyBacks = quoteObject.ExcessBuyBacks;
                    var excessBuyBacks = _mapper.Map<IEnumerable<ExcessBuyBackViewModel>, IEnumerable<ExcessBuyBack>>(modelExcessBuyBacks);
                    _unitOfWork.ExcessBuyBacks.AddRange(excessBuyBacks);

                    foreach (var excessBuyBack in excessBuyBacks)
                    {
                        var excessBuyBackId = excessBuyBack.Id;

                        Risk risk = new()
                        {
                            Id = Guid.NewGuid(),
                            ExcessBuyBackId = excessBuyBackId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.Risks.Add(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.ClientRisks.Add(clientRisk);

                        var clientRiskId = clientRisk.Id;

                        foreach (var item in quoteItems.Where(x => x.ClientRiskId == excessBuyBackId))
                        {
                            item.QuoteId = quoteId;
                            item.ClientRiskId = clientRiskId;
                            item.DateAdded = DateTime.Now;
                            item.TaxRate = taxRate;
                            item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                        }
                    }
                }

                //  House
                if (quoteObject.Houses != null)
                {
                    //  Update QuoteItems with HouseId
                    var modelHouses = quoteObject.Houses;
                    var houses = _mapper.Map<IEnumerable<HouseViewModel>, IEnumerable<House>>(modelHouses);
                    _unitOfWork.Houses.AddRange(houses);

                    foreach (var house in houses)
                    {
                        var houseId = house.Id;

                        Risk risk = new()
                        {
                            Id = Guid.NewGuid(),
                            HouseId = houseId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.Risks.Add(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.ClientRisks.Add(clientRisk);

                        var clientRiskId = clientRisk.Id;

                        foreach (var item in quoteItems.Where(x => x.ClientRiskId == houseId))
                        {
                            item.QuoteId = quoteId;
                            item.ClientRiskId = clientRiskId;
                            item.DateAdded = DateTime.Now;
                            item.TaxRate = taxRate;
                            item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                        }
                    }
                }

                //  Motor
                if (quoteObject.Motors != null)
                {
                    //  Update QuoteItems with MotorId
                    var modelMotors = quoteObject.Motors;
                    var motors = _mapper.Map<IEnumerable<MotorViewModel>, IEnumerable<Motor>>(modelMotors);
                    _unitOfWork.Motors.AddRange(motors);

                    foreach (var motor in motors)
                    {
                        var motorId = motor.Id;

                        Risk risk = new()
                        {
                            Id = Guid.NewGuid(),
                            MotorId = motorId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.Risks.Add(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.ClientRisks.Add(clientRisk);

                        var clientRiskId = clientRisk.Id;

                        foreach (var item in quoteItems.Where(x => x.ClientRiskId == motorId))
                        {
                            item.QuoteId = quoteId;
                            item.ClientRiskId = clientRiskId;
                            item.DateAdded = DateTime.Now;
                            item.TaxRate = taxRate;
                            item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                        }
                    }
                }

                //  Travel
                if (quoteObject.Travels != null)
                {
                    //  Update QuoteItems with TravelId
                    var modelTravels = quoteObject.Travels;
                    var travels = _mapper.Map<IEnumerable<TravelViewModel>, IEnumerable<Travel>>(modelTravels);
                    _unitOfWork.Travels.AddRange(travels);

                    var modelTravelBeneficiaries = quoteObject.TravelBeneficiaries;
                    var travelBeneficiaries = _mapper.Map<IEnumerable<TravelBeneficiaryViewModel>, IEnumerable<TravelBeneficiary>>(modelTravelBeneficiaries);
                    if (travelBeneficiaries != null)
                    {
                        _unitOfWork.TravelBeneficiaries.AddRange(travelBeneficiaries);
                    }

                    foreach (var travel in travels)
                    {
                        var travelId = travel.Id;

                        Risk risk = new()
                        {
                            Id = Guid.NewGuid(),
                            TravelId = travelId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.Risks.Add(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.ClientRisks.Add(clientRisk);

                        var clientRiskId = clientRisk.Id;

                        foreach (var item in quoteItems.Where(x => x.ClientRiskId == travelId))
                        {
                            item.QuoteId = quoteId;
                            item.ClientRiskId = clientRiskId;
                            item.DateAdded = DateTime.Now;
                            item.TaxRate = taxRate;
                            item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                        }
                    }
                }

                _unitOfWork.QuoteItems.AddRange(quoteItems);
                await _unitOfWork.CompleteAsync();
            }

            return Json(new { quoteObject.ClientId });
        }

        // GET: Quotes/Create
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var branchName = "No Insurer Branch";
            var portfolioClient = await _unitOfWork.PortfolioClients.GetById(portfolioClientId);
            var clientId = portfolioClient.ClientId;
            var portfolioId = portfolioClient.PortfolioId;
            var client = portfolioClient.Client;
            var clientModel = _mapper.Map<Client, ClientViewModel>(client);

            var portfolio = await _unitOfWork.Portfolios.GetById(portfolioId);
            
            var insurerBranch = await _unitOfWork.InsurerBranches.GetByName(branchName);

            var bodyTypes = await _unitOfWork.BodyTypes.GetAll(r => r.OrderBy(n => n.Name));
            var buildingConditions = await _unitOfWork.BuildingConditions.GetAll(r => r.OrderBy(n => n.Name));
            var driverTypes = await _unitOfWork.DriverTypes.GetAll(r => r.OrderBy(n => n.Name));
            var countries = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var houseConditions = await _unitOfWork.HouseConditions.GetAll(r => r.OrderBy(n => n.Name));
            var motorMakes = await _unitOfWork.MotorMakes.GetAll(r => r.OrderBy(n => n.Name));

            var motorMakeId = motorMakes.FirstOrDefault().Id;
            var motorModels = await _unitOfWork.MotorModels.GetByMotorMakeId(motorMakeId);
            var residenceTypes = await _unitOfWork.ResidenceTypes.GetAll(r => r.OrderBy(n => n.Name));
            var residenceUses = await _unitOfWork.ResidenceUses.GetAll(r => r.OrderBy(n => n.Name));
            var roofTypes = await _unitOfWork.RoofTypes.GetAll(r => r.OrderBy(n => n.Name));
            var titles = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));
            var wallTypes = await _unitOfWork.WallTypes.GetAll(r => r.OrderBy(n => n.Name));

            var coverTypes = await _unitOfWork.CoverTypes.GetAll(r => r.OrderBy(n => n.Name));
            var quoteStatuses = await _unitOfWork.QuoteStatuses.GetAll(r => r.OrderBy(n => n.Name));

            QuoteViewModel model = new()
            {
                PortfolioClientId = portfolioClientId,
                ClientId = clientId,
                PortfolioId = portfolioId,
                InsurerBranchId = insurerBranch.Id,
                PortfolioName = portfolio.Name,
                Client = clientModel,
                QuoteDate = DateTime.Now.Date,
                
                CoverTypeList = MVCHelperExtensions.ToSelectList(coverTypes, Guid.Empty),
                QuoteStatusList = MVCHelperExtensions.ToSelectList(quoteStatuses, Guid.Empty),
                BodyTypeList = MVCHelperExtensions.ToSelectList(bodyTypes, Guid.Empty),
                BuildingConditionList = MVCHelperExtensions.ToSelectList(buildingConditions, Guid.Empty),
                CountryList = MVCHelperExtensions.ToSelectList(countries, Guid.Empty),
                DayList = SelectLists.RegisteredDays(0),
                DriverTypeList = MVCHelperExtensions.ToSelectList(driverTypes, Guid.Empty),
                HouseConditionList = MVCHelperExtensions.ToSelectList(houseConditions, Guid.Empty),
                MotorMakeList = MVCHelperExtensions.ToSelectList(motorMakes, Guid.Empty),
                MotorModelList = MVCHelperExtensions.ToSelectList(motorModels, Guid.Empty),
                ResidenceTypeList = MVCHelperExtensions.ToSelectList(residenceTypes, Guid.Empty),
                ResidenceUseList = MVCHelperExtensions.ToSelectList(residenceUses, Guid.Empty),
                RoofTypeList = MVCHelperExtensions.ToSelectList(roofTypes, Guid.Empty),
                WallTypeList = MVCHelperExtensions.ToSelectList(wallTypes, Guid.Empty),
                TitleList = MVCHelperExtensions.ToSelectList(titles, Guid.Empty),
                DateRangeList = SelectLists.RegisteredYears(0)
            };

            return View(model);
        }

        // POST: Quotes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuoteObjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                };

                var modelQuoteItems = model.QuoteItems;
                if (modelQuoteItems != null)
                {
                    var quoteItems = _mapper.Map<IEnumerable<QuoteItemViewModel>, IEnumerable<QuoteItem>>(modelQuoteItems);

                    var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));

                    var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

                    var clientId = model.ClientId;

                    var modelQuote = model.Quote;
                    var quote = _mapper.Map<QuoteViewModel, Quote>(modelQuote);

                    quote.Id = Guid.NewGuid();
                    quote.QuoteDate = DateTime.Now;
                    quote.DateAdded = DateTime.Now;

                    await _unitOfWork.Quotes.Add(quote);
                    var quoteId = quote.Id;

                    //  AllRisk Unspecified
                    if (model.AllRisks != null)
                    {
                        if (model.RiskItems != null)
                        {
                            //  Create RiskItem Record
                            var modelRiskItems = model.RiskItems;
                            var riskItems = _mapper.Map<IEnumerable<RiskItemViewModel>, IEnumerable<RiskItem>>(modelRiskItems);
                            _unitOfWork.RiskItems.AddRange(riskItems);

                            //  Update QuoteItems with AllRiskId
                            var modelAllRisks = model.AllRisks;
                            var allRisks = _mapper.Map<IEnumerable<AllRiskViewModel>, IEnumerable<AllRisk>>(modelAllRisks);
                            _unitOfWork.AllRisks.AddRange(allRisks);

                            foreach (var allRisk in allRisks)
                            {
                                var allRiskId = allRisk.Id;

                                Risk risk = new()
                                {
                                    Id = Guid.NewGuid(),
                                    AllRiskId = allRiskId,
                                    DateAdded = DateTime.Now
                                };
                                await _unitOfWork.Risks.Add(risk);

                                var riskId = risk.Id;

                                ClientRisk clientRisk = new()
                                {
                                    Id = Guid.NewGuid(),
                                    ClientId = clientId,
                                    RiskId = riskId,
                                    DateAdded = DateTime.Now
                                };
                                await _unitOfWork.ClientRisks.Add(clientRisk);

                                var clientRiskId = clientRisk.Id;

                                foreach (var item in quoteItems.Where(x => x.ClientRiskId == allRiskId))
                                {
                                    item.QuoteId = quoteId;
                                    item.ClientRiskId = clientRiskId;
                                    item.DateAdded = DateTime.Now;
                                    item.TaxRate = taxRate;
                                    item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                                }
                            }
                        }
                    }

                    //  AllRisk Specified
                    if (model.AllRiskSpecifieds != null)
                    {
                        if (model.SpecifiedRiskItems != null)
                        {
                            //  Create RiskItem Record
                            var modelRiskItems = model.SpecifiedRiskItems;
                            var riskItems = _mapper.Map<IEnumerable<RiskItemViewModel>, IEnumerable<RiskItem>>(modelRiskItems);
                            _unitOfWork.RiskItems.AddRange(riskItems);

                            //  Update QuoteItems with AllRiskSpecifiedId
                            var modelAllRiskSpecifieds = model.AllRiskSpecifieds;
                            var allRiskSpecifieds = _mapper.Map<IEnumerable<AllRiskSpecifiedViewModel>, IEnumerable<AllRiskSpecified>>(modelAllRiskSpecifieds);
                            _unitOfWork.AllRiskSpecifieds.AddRange(allRiskSpecifieds);

                            foreach (var allRiskSpecified in allRiskSpecifieds)
                            {
                                var allRiskSpecifiedId = allRiskSpecified.Id;

                                Risk risk = new()
                                {
                                    Id = Guid.NewGuid(),
                                    AllRiskSpecifiedId = allRiskSpecifiedId,
                                    DateAdded = DateTime.Now
                                };
                                await _unitOfWork.Risks.Add(risk);

                                var riskId = risk.Id;

                                ClientRisk clientRisk = new()
                                {
                                    Id = Guid.NewGuid(),
                                    ClientId = clientId,
                                    RiskId = riskId,
                                    DateAdded = DateTime.Now
                                };
                                await _unitOfWork.ClientRisks.Add(clientRisk);

                                var clientRiskId = clientRisk.Id;

                                foreach (var item in quoteItems.Where(x => x.ClientRiskId == allRiskSpecifiedId))
                                {
                                    item.QuoteId = quoteId;
                                    item.ClientRiskId = clientRiskId;
                                    item.DateAdded = DateTime.Now;
                                    item.TaxRate = taxRate;
                                    item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                                }
                            }
                        }
                    }

                    //  Building
                    if (model.Buildings != null)
                    {
                        //  Update QuoteItems with BuildingId
                        var modelBuildings = model.Buildings;
                        var buildings = _mapper.Map<IEnumerable<BuildingViewModel>, IEnumerable<Building>>(modelBuildings);
                        _unitOfWork.Buildings.AddRange(buildings);

                        foreach (var building in buildings)
                        {
                            var buildingId = building.Id;

                            Risk risk = new()
                            {
                                Id = Guid.NewGuid(),
                                BuildingId = buildingId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.Risks.Add(risk);

                            var riskId = risk.Id;

                            ClientRisk clientRisk = new()
                            {
                                Id = Guid.NewGuid(),
                                ClientId = clientId,
                                RiskId = riskId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.ClientRisks.Add(clientRisk);

                            var clientRiskId = clientRisk.Id;

                            foreach (var item in quoteItems.Where(x => x.ClientRiskId == buildingId))
                            {
                                item.QuoteId = quoteId;
                                item.ClientRiskId = clientRiskId;
                                item.DateAdded = DateTime.Now;
                                item.TaxRate = taxRate;
                                item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                            }
                        }
                    }

                    //  Content
                    if (model.Contents != null)
                    {
                        //  Update QuoteItems with ContentId
                        var modelContents = model.Contents;
                        var contents = _mapper.Map<IEnumerable<ContentViewModel>, IEnumerable<Content>>(modelContents);
                        _unitOfWork.Contents.AddRange(contents);

                        foreach (var content in contents)
                        {
                            var contentId = content.Id;

                            Risk risk = new()
                            {
                                Id = Guid.NewGuid(),
                                ContentId = contentId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.Risks.Add(risk);

                            var riskId = risk.Id;

                            ClientRisk clientRisk = new()
                            {
                                Id = Guid.NewGuid(),
                                ClientId = clientId,
                                RiskId = riskId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.ClientRisks.Add(clientRisk);

                            var clientRiskId = clientRisk.Id;

                            foreach (var item in quoteItems.Where(x => x.ClientRiskId == contentId))
                            {
                                item.QuoteId = quoteId;
                                item.ClientRiskId = clientRiskId;
                                item.DateAdded = DateTime.Now;
                                item.TaxRate = taxRate;
                                item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                            }
                        }
                    }

                    //  ExcessBuyBack
                    if (model.ExcessBuyBacks != null)
                    {
                        //  Update QuoteItems with ExcessBuyBackId
                        var modelExcessBuyBacks = model.ExcessBuyBacks;
                        var excessBuyBacks = _mapper.Map<IEnumerable<ExcessBuyBackViewModel>, IEnumerable<ExcessBuyBack>>(modelExcessBuyBacks);
                        _unitOfWork.ExcessBuyBacks.AddRange(excessBuyBacks);

                        foreach (var excessBuyBack in excessBuyBacks)
                        {
                            var excessBuyBackId = excessBuyBack.Id;

                            Risk risk = new()
                            {
                                Id = Guid.NewGuid(),
                                ExcessBuyBackId = excessBuyBackId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.Risks.Add(risk);

                            var riskId = risk.Id;

                            ClientRisk clientRisk = new()
                            {
                                Id = Guid.NewGuid(),
                                ClientId = clientId,
                                RiskId = riskId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.ClientRisks.Add(clientRisk);

                            var clientRiskId = clientRisk.Id;

                            foreach (var item in quoteItems.Where(x => x.ClientRiskId == excessBuyBackId))
                            {
                                item.QuoteId = quoteId;
                                item.ClientRiskId = clientRiskId;
                                item.DateAdded = DateTime.Now;
                                item.TaxRate = taxRate;
                                item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                            }
                        }
                    }

                    //  House
                    if (model.Houses != null)
                    {
                        //  Update QuoteItems with HouseId
                        var modelHouses = model.Houses;
                        var houses = _mapper.Map<IEnumerable<HouseViewModel>, IEnumerable<House>>(modelHouses);
                        _unitOfWork.Houses.AddRange(houses);

                        foreach (var house in houses)
                        {
                            var houseId = house.Id;

                            Risk risk = new()
                            {
                                Id = Guid.NewGuid(),
                                HouseId = houseId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.Risks.Add(risk);

                            var riskId = risk.Id;

                            ClientRisk clientRisk = new()
                            {
                                Id = Guid.NewGuid(),
                                ClientId = clientId,
                                RiskId = riskId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.ClientRisks.Add(clientRisk);

                            var clientRiskId = clientRisk.Id;

                            foreach (var item in quoteItems.Where(x => x.ClientRiskId == houseId))
                            {
                                item.QuoteId = quoteId;
                                item.ClientRiskId = clientRiskId;
                                item.DateAdded = DateTime.Now;
                                item.TaxRate = taxRate;
                                item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                            }
                        }
                    }

                    //  Motor
                    if (model.Motors != null)
                    {
                        //  Update QuoteItems with MotorId
                        var modelMotors = model.Motors;
                        var motors = _mapper.Map<IEnumerable<MotorViewModel>, IEnumerable<Motor>>(modelMotors);
                        _unitOfWork.Motors.AddRange(motors);

                        foreach (var motor in motors)
                        {
                            var motorId = motor.Id;

                            Risk risk = new()
                            {
                                Id = Guid.NewGuid(),
                                MotorId = motorId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.Risks.Add(risk);

                            var riskId = risk.Id;

                            ClientRisk clientRisk = new()
                            {
                                Id = Guid.NewGuid(),
                                ClientId = clientId,
                                RiskId = riskId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.ClientRisks.Add(clientRisk);

                            var clientRiskId = clientRisk.Id;

                            foreach (var item in quoteItems.Where(x => x.ClientRiskId == motorId))
                            {
                                item.QuoteId = quoteId;
                                item.ClientRiskId = clientRiskId;
                                item.DateAdded = DateTime.Now;
                                item.TaxRate = taxRate;
                                item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                            }
                        }
                    }

                    //  Travel
                    if (model.Travels != null)
                    {
                        //  Update QuoteItems with TravelId
                        var modelTravels = model.Travels;
                        var travels = _mapper.Map<IEnumerable<TravelViewModel>, IEnumerable<Travel>>(modelTravels);
                        _unitOfWork.Travels.AddRange(travels);

                        var modelTravelBeneficiaries = model.TravelBeneficiaries;
                        var travelBeneficiaries = _mapper.Map<IEnumerable<TravelBeneficiaryViewModel>, IEnumerable<TravelBeneficiary>>(modelTravelBeneficiaries);
                        if (travelBeneficiaries != null)
                        {
                            _unitOfWork.TravelBeneficiaries.AddRange(travelBeneficiaries);
                        }

                        foreach (var travel in travels)
                        {
                            var travelId = travel.Id;

                            Risk risk = new()
                            {
                                Id = Guid.NewGuid(),
                                TravelId = travelId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.Risks.Add(risk);

                            var riskId = risk.Id;

                            ClientRisk clientRisk = new()
                            {
                                Id = Guid.NewGuid(),
                                ClientId = clientId,
                                RiskId = riskId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.ClientRisks.Add(clientRisk);

                            var clientRiskId = clientRisk.Id;

                            foreach (var item in quoteItems.Where(x => x.ClientRiskId == travelId))
                            {
                                item.QuoteId = quoteId;
                                item.ClientRiskId = clientRiskId;
                                item.DateAdded = DateTime.Now;
                                item.TaxRate = taxRate;
                                item.TaxAmount = item.Premium - (item.Premium / (1 + taxRate / 100));
                            }
                        }
                    }

                    _unitOfWork.QuoteItems.AddRange(quoteItems);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction("PortfolioClientQuotes", "Quotes", new { model.Quote.PortfolioClientId });
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Quotation(Guid id)
        {
            var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            ViewBag.TaxRate = taxRate;
            var result = await _unitOfWork.Quotes.GetById(id);
            var model = _mapper.Map<Quote, QuoteViewModel>(result);
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            var result = await _unitOfWork.Quotes.GetById(id);
            var model = _mapper.Map<Quote, QuoteViewModel>(result);

            var insurerBranchId = model.InsurerBranchId;

            var insurerBranch = await _unitOfWork.InsurerBranches.GetById(insurerBranchId);
            var insurerId = Guid.Empty;

            if(insurerBranch != null)
            {
                insurerId = insurerBranch.InsurerId;
            }

            var portfolioClient = await _unitOfWork.PortfolioClients.GetById(model.PortfolioClientId);
            
            var quoteStatuses = await _unitOfWork.QuoteStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            var salesTypes = await _unitOfWork.SalesTypes.GetAll(r => r.OrderBy(n => n.Name));
            var policyTypes = await _unitOfWork.PolicyTypes.GetAll(r => r.OrderBy(n => n.Name));
            var paymentMethods = await _unitOfWork.PaymentMethods.GetAll(r => r.OrderBy(n => n.Name));
            var insurerBranches = await _unitOfWork.InsurerBranches.GetByInsurerId(insurerId);

            model.ClientId = portfolioClient.ClientId;
            model.PortfolioId = portfolioClient.PortfolioId;
            model.PortfolioName = portfolioClient.Portfolio.Name;
            model.InsurerId = insurerId;
            model.TaxRate = taxRate;
            model.DayList = SelectLists.RegisteredDays(model.RunDay);
            model.QuoteStatusList = MVCHelperExtensions.ToSelectList(quoteStatuses, model.QuoteStatusId);
            model.SalesTypeList = MVCHelperExtensions.ToSelectList(salesTypes, model.SalesTypeId.Value);
            model.PolicyTypeList = MVCHelperExtensions.ToSelectList(policyTypes, model.PolicyTypeId.Value);
            model.PaymentMethodList = MVCHelperExtensions.ToSelectList(paymentMethods, model.PaymentMethodId.Value);
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, insurerId);
            model.InsurerBranchList = MVCHelperExtensions.ToSelectList(insurerBranches, insurerBranchId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, QuoteViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var quote = _mapper.Map<QuoteViewModel, Quote>(model);
                quote.DateModified = DateTime.Now;

                _unitOfWork.Quotes.Update(model.Id, quote);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }

            var quoteStatuses = await _unitOfWork.QuoteStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var insurers = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            var salesTypes = await _unitOfWork.SalesTypes.GetAll(r => r.OrderBy(n => n.Name));
            var policyTypes = await _unitOfWork.PolicyTypes.GetAll(r => r.OrderBy(n => n.Name));
            var paymentMethods = await _unitOfWork.PaymentMethods.GetAll(r => r.OrderBy(n => n.Name));
            var insurerBranches = await _unitOfWork.InsurerBranches.GetByInsurerId(model.InsurerId);

            model.QuoteStatusList = MVCHelperExtensions.ToSelectList(quoteStatuses, model.QuoteStatusId);
            model.SalesTypeList = MVCHelperExtensions.ToSelectList(salesTypes, model.SalesTypeId.Value);
            model.PolicyTypeList = MVCHelperExtensions.ToSelectList(policyTypes, model.PolicyTypeId.Value);
            model.PaymentMethodList = MVCHelperExtensions.ToSelectList(paymentMethods, model.PaymentMethodId.Value);
            model.InsurerList = MVCHelperExtensions.ToSelectList(insurers, model.InsurerId);
            model.InsurerBranchList = MVCHelperExtensions.ToSelectList(insurerBranches, model.InsurerBranchId);
            return View(model);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _unitOfWork.Quotes.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<Quote, QuoteViewModel>(result);
            return View(model);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _unitOfWork.Quotes.GetById(id);
            await _unitOfWork.Quotes.Delete(id);

            return RedirectToAction(nameof(Details), "PortfolioClients", new { result.PortfolioClientId });
        }
    }
}
