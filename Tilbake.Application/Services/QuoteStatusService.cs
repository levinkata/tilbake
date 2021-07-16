﻿using AutoMapper;
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
    public class QuoteStatusService : IQuoteStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuoteStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(QuoteStatusSaveResource resource)
        {
            var quoteStatus = _mapper.Map<QuoteStatusSaveResource, QuoteStatus>(resource);
            quoteStatus.Id = Guid.NewGuid();

            await _unitOfWork.QuoteStatuses.AddAsync(quoteStatus).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.QuoteStatuses.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(QuoteStatusResource resource)
        {
            var quoteStatus = _mapper.Map<QuoteStatusResource, QuoteStatus>(resource);
            await _unitOfWork.QuoteStatuses.DeleteAsync(quoteStatus).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<QuoteStatusResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.QuoteStatuses.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<QuoteStatus>, IEnumerable<QuoteStatusResource>>(result);

            return resources;
        }

        public async Task<QuoteStatusResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.QuoteStatuses.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<QuoteStatus, QuoteStatusResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(QuoteStatusResource resource)
        {
            var quoteStatus = _mapper.Map<QuoteStatusResource, QuoteStatus>(resource);
            await _unitOfWork.QuoteStatuses.UpdateAsync(resource.Id, quoteStatus).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}