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

        public async Task<int> AddAsync(QuoteObjectResource resource)
        {
            var quoteItems = resource.QuoteItems;
            if(quoteItems == null)
            {
                throw new ArgumentNullException(nameof(quoteItems));
            }

            var clientId = resource.ClientId;
            
            var quote = resource.Quote;
            quote.Id = Guid.NewGuid();
            quote.QuoteDate = DateTime.Now;
            await _unitOfWork.Quotes.AddAsync(quote).ConfigureAwait(true);
            var quoteId = quote.Id;

            if (resource.AllRisks != null)
            {
                //  Update QuoteItems with AllRiskId
                int ao = resource.AllRisks.Length;
                var allRisks = resource.AllRisks;
                await _unitOfWork.AllRisks.AddRangeAsync(allRisks).ConfigureAwait(true);

                for (int i = 0; i < ao; i++)
                {
                    var allRiskId = allRisks[i].Id;

                    Risk risk = new Risk()
                    {
                        Id = Guid.NewGuid(),
                        AllRiskId = allRiskId
                    };
                    await _unitOfWork.Risks.AddAsync(risk).ConfigureAwait(true);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new ClientRisk()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk).ConfigureAwait(true);

                    var clientRiskId = clientRisk.Id;

                    foreach (var item in quoteItems.Where(x => x.ClientRiskId == allRiskId))
                    {
                        item.QuoteId = quoteId;
                        item.ClientRiskId = clientRiskId;
                    }
                }                
            }

            if (resource.Contents != null)
            {
                //  Update QuoteItems with ContentId
                int co = resource.Contents.Length;
                var contents = resource.Contents;
                await _unitOfWork.Contents.AddRangeAsync(contents).ConfigureAwait(true);

                for (int i = 0; i < co; i++)
                {
                    var contentId = contents[i].Id;

                    Risk risk = new Risk()
                    {
                        Id = Guid.NewGuid(),
                        ContentId = contentId
                    };
                    await _unitOfWork.Risks.AddAsync(risk).ConfigureAwait(true);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new ClientRisk()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk).ConfigureAwait(true);

                    var clientRiskId = clientRisk.Id;

                    foreach (var item in quoteItems.Where(x => x.ClientRiskId == contentId))
                    {
                        item.QuoteId = quoteId;
                        item.ClientRiskId = clientRiskId;
                    }
                }
            }

            if(resource.Houses != null)
            {
                //  Update QuoteItems with HouseId
                int ho = resource.Houses.Length;
                var houses = resource.Houses;
                await _unitOfWork.Houses.AddRangeAsync(houses).ConfigureAwait(true);

                for (int i = 0; i < ho; i++)
                {
                    var houseId = houses[i].Id;

                    Risk risk = new Risk()
                    {
                        Id = Guid.NewGuid(),
                        HouseId = houseId
                    };
                    await _unitOfWork.Risks.AddAsync(risk).ConfigureAwait(true);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new ClientRisk()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk).ConfigureAwait(true);

                    var clientRiskId = clientRisk.Id;

                    foreach (var item in quoteItems.Where(x => x.ClientRiskId == houseId))
                    {
                        item.QuoteId = quoteId;
                        item.ClientRiskId = clientRiskId;
                    }
                }
            }

            if(resource.Motors != null)
            {
                //  Update QuoteItems with MotorId
                int mo = resource.Motors.Length;
                var motors = resource.Motors;
                await _unitOfWork.Motors.AddRangeAsync(motors).ConfigureAwait(true);

                for (int i = 0; i < mo; i++)
                {
                    var motorId = motors[i].Id;

                    Risk risk = new Risk()
                    {
                        Id = Guid.NewGuid(),
                        MotorId = motorId
                    };
                    await _unitOfWork.Risks.AddAsync(risk).ConfigureAwait(true);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new ClientRisk()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk).ConfigureAwait(true);

                    var clientRiskId = clientRisk.Id;

                    foreach (var item in quoteItems.Where(x => x.ClientRiskId == motorId))
                    {
                        item.QuoteId = quoteId;
                        item.ClientRiskId = clientRiskId;
                    }
                }
            }

            await _unitOfWork.QuoteItems.AddRangeAsync(quoteItems).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Quotes.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(QuoteResource resource)
        {
            var quote = _mapper.Map<QuoteResource, Quote>(resource);
            await _unitOfWork.Quotes.DeleteAsync(quote).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<QuoteResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Quotes.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.QuoteNumber);

            var resources = _mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteResource>>(result);

            return resources;
        }

        public async Task<QuoteResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Quotes.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<Quote, QuoteResource>(result);

            return resources;
        }

        public async Task<IEnumerable<QuoteResource>> GetByPortfolioAsync(Guid portfolioId)
        {
            var result = await Task.Run(() => _unitOfWork.Quotes.GetByPortfolioAsync(portfolioId)).ConfigureAwait(true);
            result = result.OrderBy(n => n.QuoteNumber);

            var resources = _mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteResource>>(result);

            return resources;
        }

        public async Task<IEnumerable<QuoteResource>> GetByPortfolioClientAsync(Guid portfolioClientId)
        {
            var result = await Task.Run(() => _unitOfWork.Quotes.GetByPortfolioClientAsync(portfolioClientId)).ConfigureAwait(true);
            result = result.OrderBy(n => n.QuoteNumber);

            var resources = _mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteResource>>(result);

            return resources;
        }

        public async Task<QuoteResource> GetByQuoteNumberAsync(int quoteNumber)
        {
            var result = await _unitOfWork.Quotes.GetByQuoteNumberAsync(quoteNumber).ConfigureAwait(true);
            var resources = _mapper.Map<Quote, QuoteResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(QuoteResource resource)
        {
            var quote = _mapper.Map<QuoteResource, Quote>(resource);
            await _unitOfWork.Quotes.UpdateAsync(resource.Id, quote).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
