using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

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

        public async Task<QuoteResource> AddAsync(QuoteObjectResource resource)
        {
            var resourceQuoteItems = resource.QuoteItems;
            var quoteItems = _mapper.Map<IEnumerable<QuoteItemResource>, IEnumerable<QuoteItem>>(resourceQuoteItems);

            var taxes = await _unitOfWork.Taxes.GetAllAsync(
                                            null,
                                            r => r.OrderByDescending(n => n.TaxDate));

            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            var clientId = resource.ClientId;

            var resourceQuote = resource.Quote;
            var quote = _mapper.Map<QuoteResource, Quote>(resourceQuote);

            quote.Id = Guid.NewGuid();
            quote.QuoteDate = DateTime.Now;
            quote.DateAdded = DateTime.Now;
            
            await _unitOfWork.Quotes.AddAsync(quote);
            var quoteId = quote.Id;

            //  AllRisk Unspecified
            if (resource.AllRisks != null)
            {
                if (resource.RiskItems != null)
                {
                    //  Create RiskItem Record
                    var resourceRiskItems = resource.RiskItems;
                    var riskItems = _mapper.Map<IEnumerable<RiskItemResource>, IEnumerable<RiskItem>>(resourceRiskItems);
                    await _unitOfWork.RiskItems.AddRangeAsync(riskItems);

                    //  Update QuoteItems with AllRiskId
                    var resourceAllRisks = resource.AllRisks;
                    var allRisks = _mapper.Map<IEnumerable<AllRiskResource>, IEnumerable<AllRisk>>(resourceAllRisks);
                    await _unitOfWork.AllRisks.AddRangeAsync(allRisks);

                    foreach (var allRisk in allRisks)
                    {
                        var allRiskId = allRisk.Id;

                        Risk risk = new()
                        {
                            Id = Guid.NewGuid(),
                            AllRiskId = allRiskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.Risks.AddAsync(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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
                    await _unitOfWork.RiskItems.AddRangeAsync(riskItems);

                    //  Update QuoteItems with AllRiskSpecifiedId
                    var resourceAllRiskSpecifieds = resource.AllRiskSpecifieds;
                    var allRiskSpecifieds = _mapper.Map<IEnumerable<AllRiskSpecifiedResource>, IEnumerable<AllRiskSpecified>>(resourceAllRiskSpecifieds);
                    await _unitOfWork.AllRiskSpecifieds.AddRangeAsync(allRiskSpecifieds);

                    foreach (var allRiskSpecified in allRiskSpecifieds)
                    {
                        var allRiskSpecifiedId = allRiskSpecified.Id;

                        Risk risk = new()
                        {
                            Id = Guid.NewGuid(),
                            AllRiskSpecifiedId = allRiskSpecifiedId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.Risks.AddAsync(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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
                await _unitOfWork.Buildings.AddRangeAsync(buildings);

                foreach (var building in buildings)
                {
                    var buildingId = building.Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        BuildingId = buildingId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.Risks.AddAsync(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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
                await _unitOfWork.Contents.AddRangeAsync(contents);

                foreach (var content in contents)
                {
                    var contentId = content.Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        ContentId = contentId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.Risks.AddAsync(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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
                await _unitOfWork.ExcessBuyBacks.AddRangeAsync(excessBuyBacks);

                foreach (var excessBuyBack in excessBuyBacks)
                {
                    var excessBuyBackId = excessBuyBack.Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        ExcessBuyBackId = excessBuyBackId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.Risks.AddAsync(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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
                await _unitOfWork.Houses.AddRangeAsync(houses);

                foreach (var house in houses)
                {
                    var houseId = house.Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        HouseId = houseId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.Risks.AddAsync(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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
                await _unitOfWork.Motors.AddRangeAsync(motors);

                foreach (var motor in motors)
                {
                    var motorId = motor.Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        MotorId = motorId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.Risks.AddAsync(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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
                await _unitOfWork.Travels.AddRangeAsync(travels);

                var resourceTravelBeneficiaries = resource.TravelBeneficiaries;
                var travelBeneficiaries = _mapper.Map<IEnumerable<TravelBeneficiaryResource>, IEnumerable<TravelBeneficiary>>(resourceTravelBeneficiaries);
                if(travelBeneficiaries != null)
                {
                    await _unitOfWork.TravelBeneficiaries.AddRangeAsync(travelBeneficiaries);
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
                    await _unitOfWork.Risks.AddAsync(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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

            await _unitOfWork.QuoteItems.AddRangeAsync(quoteItems);
            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<Quote, QuoteResource>(quote);
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Quotes.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(QuoteResource resource)
        {
            var quote = _mapper.Map<QuoteResource, Quote>(resource);
            await _unitOfWork.Quotes.DeleteAsync(quote);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<QuoteResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Quotes.GetAllAsync(
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
            var result = await _unitOfWork.Quotes.GetFirstOrDefaultAsync(
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
                        await _unitOfWork.Quotes.UpdateAsync(result.Id, result);
                        await _unitOfWork.SaveAsync();

                        result = await _unitOfWork.Quotes.GetFirstOrDefaultAsync(
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
            var result = await _unitOfWork.Quotes.GetAllAsync(
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
            var result = await _unitOfWork.Quotes.GetAllAsync(
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
            var result = await _unitOfWork.Quotes.GetFirstOrDefaultAsync(
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

        public async Task<QuoteResource> UpdateAsync(QuoteResource resource)
        {
            var quote = _mapper.Map<QuoteResource, Quote>(resource);
            quote.DateModified = DateTime.Now;

            await _unitOfWork.Quotes.UpdateAsync(resource.Id, quote);
            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<Quote, QuoteResource>(quote);
            return result;
        }
    }
}
