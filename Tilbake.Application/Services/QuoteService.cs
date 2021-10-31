using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

namespace Tilbake.Application.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuoteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(QuoteObjectResource resource)
        {
            var resourceQuoteItems = resource.QuoteItems;
            var quoteItems = _mapper.Map<IEnumerable<QuoteItemResource>, IEnumerable<QuoteItem>>(resourceQuoteItems);

            var taxes = await _unitOfWork.Taxes.FindAllAsync(
                                            null,
                                            r => r.OrderByDescending(n => n.TaxDate));

            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            var clientId = resource.ClientId;

            var resourceQuote = resource.Quote;
            var quote = _mapper.Map<QuoteResource, Quote>(resourceQuote);

            quote.Id = Guid.NewGuid();
            quote.QuoteDate = DateTime.Now;
            quote.DateAdded = DateTime.Now;
            
            _unitOfWork.Quotes.Add(quote);
            var quoteId = quote.Id;

            //  AllRisk Unspecified
            if (resource.AllRisks != null)
            {
                if (resource.RiskItems != null)
                {
                    //  Create RiskItem Record
                    var resourceRiskItems = resource.RiskItems;
                    var riskItems = _mapper.Map<IEnumerable<RiskItemResource>, IEnumerable<RiskItem>>(resourceRiskItems);
                    _unitOfWork.RiskItems.AddRange(riskItems);

                    //  Update QuoteItems with AllRiskId
                    var resourceAllRisks = resource.AllRisks;
                    var allRisks = _mapper.Map<IEnumerable<AllRiskResource>, IEnumerable<AllRisk>>(resourceAllRisks);
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
                        _unitOfWork.Risks.Add(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        _unitOfWork.ClientRisks.Add(clientRisk);

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
            if (resource.AllRiskSpecifieds != null)
            {
                if (resource.SpecifiedRiskItems != null)
                {
                    //  Create RiskItem Record
                    var resourceRiskItems = resource.SpecifiedRiskItems;
                    var riskItems = _mapper.Map<IEnumerable<RiskItemResource>, IEnumerable<RiskItem>>(resourceRiskItems);
                    _unitOfWork.RiskItems.AddRange(riskItems);

                    //  Update QuoteItems with AllRiskSpecifiedId
                    var resourceAllRiskSpecifieds = resource.AllRiskSpecifieds;
                    var allRiskSpecifieds = _mapper.Map<IEnumerable<AllRiskSpecifiedResource>, IEnumerable<AllRiskSpecified>>(resourceAllRiskSpecifieds);
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
                        _unitOfWork.Risks.Add(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        _unitOfWork.ClientRisks.Add(clientRisk);

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
            if (resource.Buildings != null)
            {
                //  Update QuoteItems with BuildingId
                var resourceBuildings = resource.Buildings;
                var buildings = _mapper.Map<IEnumerable<BuildingResource>, IEnumerable<Building>>(resourceBuildings);
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
                    _unitOfWork.Risks.Add(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.ClientRisks.Add(clientRisk);

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
            if (resource.Contents != null)
            {
                //  Update QuoteItems with ContentId
                var resourceContents = resource.Contents;
                var contents = _mapper.Map<IEnumerable<ContentResource>, IEnumerable<Content>>(resourceContents);
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
                    _unitOfWork.Risks.Add(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.ClientRisks.Add(clientRisk);

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
            if (resource.ExcessBuyBacks != null)
            {
                //  Update QuoteItems with ExcessBuyBackId
                var resourceExcessBuyBacks = resource.ExcessBuyBacks;
                var excessBuyBacks = _mapper.Map<IEnumerable<ExcessBuyBackResource>, IEnumerable<ExcessBuyBack>>(resourceExcessBuyBacks);
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
                    _unitOfWork.Risks.Add(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.ClientRisks.Add(clientRisk);

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
            if (resource.Houses != null)
            {
                //  Update QuoteItems with HouseId
                var resourceHouses = resource.Houses;
                var houses = _mapper.Map<IEnumerable<HouseResource>, IEnumerable<House>>(resourceHouses);
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
                    _unitOfWork.Risks.Add(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.ClientRisks.Add(clientRisk);

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
            if(resource.Motors != null)
            {
                //  Update QuoteItems with MotorId
                var resourceMotors = resource.Motors;
                var motors = _mapper.Map<IEnumerable<MotorResource>, IEnumerable<Motor>>(resourceMotors);
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
                    _unitOfWork.Risks.Add(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.ClientRisks.Add(clientRisk);

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
            if(resource.Travels != null)
            {
                //  Update QuoteItems with TravelId
                var resourceTravels = resource.Travels;
                var travels = _mapper.Map<IEnumerable<TravelResource>, IEnumerable<Travel>>(resourceTravels);
                _unitOfWork.Travels.AddRange(travels);

                var resourceTravelBeneficiaries = resource.TravelBeneficiaries;
                var travelBeneficiaries = _mapper.Map<IEnumerable<TravelBeneficiaryResource>, IEnumerable<TravelBeneficiary>>(resourceTravelBeneficiaries);
                if(travelBeneficiaries != null)
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
                    _unitOfWork.Risks.Add(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.ClientRisks.Add(clientRisk);

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
            _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Quotes.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<QuoteResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Quotes.FindAllAsync(
                                                    null,
                                                    r => r.OrderBy(n => n.QuoteNumber),
                                                    r => r.QuoteItems,
                                                    r => r.QuoteStatus,
                                                    r => r.InsurerBranch,
                                                    r => r.PaymentMethod,
                                                    r => r.PolicyType,
                                                    r => r.SalesType,
                                                    r => r.InsurerBranch.Insurer,
                                                    r => r.PortfolioClient,
                                                    r => r.PortfolioClient.Client);

            var resources = _mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteResource>>(result);
            return resources;
        }

        public async Task<QuoteResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Quotes.GetByIdAsync(
                                                    r => r.Id == id,
                                                    r => r.QuoteItems,
                                                    r => r.QuoteStatus,
                                                    r => r.InsurerBranch,
                                                    r => r.PaymentMethod,
                                                    r => r.PolicyType,
                                                    r => r.SalesType,
                                                    r => r.InsurerBranch.Insurer,
                                                    r => r.PortfolioClient,
                                                    r => r.PortfolioClient.Client);

            var insurerBranchId = result.InsurerBranchId;
            var quoteitems = result.QuoteItems;
            var isFulfilled = result.IsFulfilled;

            if (!isFulfilled)
            {
                if (insurerBranchId != Guid.Empty && result.PolicyTypeId != Guid.Empty && result.SalesTypeId != Guid.Empty && result.PaymentMethodId != Guid.Empty &&
                    !string.IsNullOrEmpty(result.PolicyTypeId.ToString()) && !string.IsNullOrEmpty(result.SalesTypeId.ToString()) && !string.IsNullOrEmpty(result.PaymentMethodId.ToString()))
                {
                    var isRated = false;
                    foreach (var item in quoteitems)
                    {
                        if (item.SumInsured == 0 || item.Premium == 0 || String.IsNullOrEmpty(item.Excess))
                        {
                            isRated = false;
                            break;
                        }
                        else
                        {
                            isRated = true;
                        }
                    }

                    if (isRated)
                    {
                        result.IsFulfilled = true;
                        _unitOfWork.Quotes.Update(result.Id, result);
                        _unitOfWork.SaveAsync();

                        result = await _unitOfWork.Quotes.GetByIdAsync(
                                                    r => r.Id == id,
                                                    r => r.QuoteItems,
                                                    r => r.QuoteStatus,
                                                    r => r.InsurerBranch,
                                                    r => r.PaymentMethod,
                                                    r => r.PolicyType,
                                                    r => r.SalesType,
                                                    r => r.InsurerBranch.Insurer,
                                                    r => r.PortfolioClient,
                                                    r => r.PortfolioClient.Client);
                    }
                }
            }

            var resource = _mapper.Map<Quote, QuoteResource>(result);
            return resource;
        }

        public async Task<IEnumerable<QuoteResource>> GetByPortfolioAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.Quotes.FindAllAsync(
                                                    r => r.PortfolioClient.PortfolioId == portfolioId,
                                                    r => r.OrderBy(p => p.QuoteNumber),
                                                    r => r.QuoteItems,
                                                    r => r.QuoteStatus,
                                                    r => r.InsurerBranch,
                                                    r => r.PaymentMethod,
                                                    r => r.PolicyType,
                                                    r => r.SalesType,
                                                    r => r.InsurerBranch.Insurer,
                                                    r => r.PortfolioClient,
                                                    r => r.PortfolioClient.Client);

            var resources = _mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteResource>>(result);
            return resources;
        }
        public async Task<IEnumerable<QuoteResource>> GetByPortfolioClientAsync(Guid portfolioClientId)
        {
            var result = await _unitOfWork.Quotes.FindAllAsync(
                                                    r => r.PortfolioClientId == portfolioClientId,
                                                    r => r.OrderBy(p => p.QuoteNumber),
                                                    r => r.QuoteItems,
                                                    r => r.QuoteStatus,
                                                    r => r.InsurerBranch,
                                                    r => r.PaymentMethod,
                                                    r => r.PolicyType,
                                                    r => r.SalesType,
                                                    r => r.InsurerBranch.Insurer,
                                                    r => r.PortfolioClient,
                                                    r => r.PortfolioClient.Client);

            var resources = _mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteResource>>(result);
            return resources;
        }

        public async Task<QuoteResource> GetByQuoteNumberAsync(int quoteNumber)
        {
            var result = await _unitOfWork.Quotes.GetByIdAsync(
                                                    r => r.QuoteNumber == quoteNumber,
                                                    r => r.QuoteItems,
                                                    r => r.QuoteStatus,
                                                    r => r.InsurerBranch,
                                                    r => r.PaymentMethod,
                                                    r => r.PolicyType,
                                                    r => r.SalesType,
                                                    r => r.InsurerBranch.Insurer,
                                                    r => r.PortfolioClient,
                                                    r => r.PortfolioClient.Client);

            var resource = _mapper.Map<Quote, QuoteResource>(result);
            return resource;
        }

        public async void Update(QuoteResource resource)
        {
            var quote = _mapper.Map<QuoteResource, Quote>(resource);
            quote.DateModified = DateTime.Now;

            _unitOfWork.Quotes.Update(resource.Id, quote);
            _unitOfWork.SaveAsync();
        }
    }
}
