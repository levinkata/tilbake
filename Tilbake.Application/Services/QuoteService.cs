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
            var clientId = resource.ClientId;
            
            var quote = resource.Quote;
            quote.Id = Guid.NewGuid();
            quote.QuoteDate = DateTime.Now;
            await _unitOfWork.Quotes.AddAsync(quote).ConfigureAwait(true);
            var quoteId = quote.Id;

            int mo = resource.Motors.Length;
            var motors = resource.Motors;
            await _unitOfWork.Motors.AddRangeAsync(motors).ConfigureAwait(true);

            var quoteItems = resource.QuoteItems;

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
