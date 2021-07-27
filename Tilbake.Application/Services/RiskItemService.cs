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
    public class RiskItemService : IRiskItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RiskItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(RiskItemSaveResource resource)
        {
            var riskItem = _mapper.Map<RiskItemSaveResource, RiskItem>(resource);
            riskItem.Id = Guid.NewGuid();

            await _unitOfWork.RiskItems.AddAsync(riskItem).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.RiskItems.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(RiskItemResource resource)
        {
            var riskItem = _mapper.Map<RiskItemResource, RiskItem>(resource);
            await _unitOfWork.RiskItems.DeleteAsync(riskItem).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<RiskItemResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.RiskItems.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Description);

            var resources = _mapper.Map<IEnumerable<RiskItem>, IEnumerable<RiskItemResource>>(result);

            return resources;
        }

        public async Task<RiskItemResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RiskItems.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<RiskItem, RiskItemResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(RiskItemResource resource)
        {
            var riskItem = _mapper.Map<RiskItemResource, RiskItem>(resource);
            await _unitOfWork.RiskItems.UpdateAsync(resource.Id, riskItem).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
