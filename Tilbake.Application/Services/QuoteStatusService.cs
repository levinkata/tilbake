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
    public class QuoteStatusService : IQuoteStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuoteStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(QuoteStatusSaveResource resource)
        {
            var quoteStatus = _mapper.Map<QuoteStatusSaveResource, QuoteStatus>(resource);
            quoteStatus.Id = Guid.NewGuid();

            _unitOfWork.QuoteStatuses.Add(quoteStatus);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.QuoteStatuses.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<QuoteStatusResource>> GetAllAsync()
        {
            var result = await _unitOfWork.QuoteStatuses.FindAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<QuoteStatus>, IEnumerable<QuoteStatusResource>>(result);
            return resources;
        }

        public async Task<QuoteStatusResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.QuoteStatuses.GetByIdAsync(id);
            var resource = _mapper.Map<QuoteStatus, QuoteStatusResource>(result);
            return resource;
        }

        public async void Update(QuoteStatusResource resource)
        {
            var quoteStatus = _mapper.Map<QuoteStatusResource, QuoteStatus>(resource);
            _unitOfWork.QuoteStatuses.Update(resource.Id, quoteStatus);

            await _unitOfWork.SaveAsync();
        }
    }
}
