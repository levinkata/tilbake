using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Services
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

        public async Task<QuoteItemResource> GetFirstOrDefaultAsync(Guid id)
        {
            var result = await _unitOfWork.QuoteItems.GetFirstOrDefaultAsync(p => p.Id == id, p => p.CoverType);
            var resource = _mapper.Map<QuoteItem, QuoteItemResource>(result);

            return resource;
        }

        public async Task<QuoteItemObjectResource> GetRisksAsync(Guid id)
        {
            var resultAllRisk = await _unitOfWork.QuoteItems.GetAllRiskAsync(id);
            var resultContent = await _unitOfWork.QuoteItems.GetContentAsync(id);
            var resultHouse = await _unitOfWork.QuoteItems.GetHouseAsync(id);
            var resultMotor = await _unitOfWork.QuoteItems.GetMotorAsync(id);

            var resourceAllRisk = _mapper.Map<AllRisk, AllRiskResource>(resultAllRisk);
            var resourceContent = _mapper.Map<Content, ContentResource>(resultContent);
            var resourceHouse = _mapper.Map<House, HouseResource>(resultHouse);
            var resourceMotor = _mapper.Map<Motor, MotorResource>(resultMotor);

            QuoteItemObjectResource quoteItemObjectResource = new()
            {
                AllRisk = resourceAllRisk,
                Content = resourceContent,
                House = resourceHouse,
                Motor = resourceMotor
            };

            return quoteItemObjectResource;
        }

        public async Task<int> UpdateAsync(QuoteItemResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource);
            await _unitOfWork.QuoteItems.UpdateAsync(resource.Id, quoteItem).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
