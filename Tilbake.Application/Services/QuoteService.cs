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

        public async Task<int> AddAsync(QuoteSaveResource resource)
        {
            var quote = _mapper.Map<QuoteSaveResource, Quote>(resource);
            quote.Id = Guid.NewGuid();

            await _unitOfWork.Quotes.AddAsync(quote).ConfigureAwait(true);
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
