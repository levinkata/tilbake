using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Resources
{
    public class QuoteItemService : IQuoteItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuoteItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.QuoteItems.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<QuoteItemResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.QuoteItems.GetByIdAsync(id);
            var resource = _mapper.Map<QuoteItem, QuoteItemResource>(result);

            return resource;
        }

        public async Task<IEnumerable<QuoteItemResource>> GetByQuoteIdAsync(Guid quoteId)
        {
            var result = await Task.Run(() => _unitOfWork.QuoteItems.GetByQuoteIdAsync(quoteId));
            var resources = _mapper.Map<IEnumerable<QuoteItem>, IEnumerable<QuoteItemResource>>(result);
            
            return resources;
        }

        public async Task<int> UpdateAsync(QuoteItemResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource);
            await _unitOfWork.QuoteItems.UpdateAsync(resource.Id, quoteItem).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
