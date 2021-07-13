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
    public class PolicyStatusService : IPolicyStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PolicyStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PolicyStatusSaveResource resource)
        {
            var policyStatus = _mapper.Map<PolicyStatusSaveResource, PolicyStatus>(resource);
            policyStatus.Id = Guid.NewGuid();

            await _unitOfWork.PolicyStatuses.AddAsync(policyStatus).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PolicyStatuses.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(PolicyStatusResource resource)
        {
            var policyStatus = _mapper.Map<PolicyStatusResource, PolicyStatus>(resource);
            await _unitOfWork.PolicyStatuses.DeleteAsync(policyStatus).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<PolicyStatusResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.PolicyStatuses.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<PolicyStatus>, IEnumerable<PolicyStatusResource>>(result);

            return resources;
        }

        public async Task<PolicyStatusResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PolicyStatuses.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<PolicyStatus, PolicyStatusResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(PolicyStatusResource resource)
        {
            var policyStatus = _mapper.Map<PolicyStatusResource, PolicyStatus>(resource);
            await _unitOfWork.PolicyStatuses.UpdateAsync(resource.Id, policyStatus).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
