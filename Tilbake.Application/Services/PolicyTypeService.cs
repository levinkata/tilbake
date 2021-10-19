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
    public class PolicyTypeService : IPolicyTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PolicyTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PolicyTypeSaveResource resource)
        {
            var policyType = _mapper.Map<PolicyTypeSaveResource, PolicyType>(resource);
            policyType.Id = Guid.NewGuid();

            await _unitOfWork.PolicyTypes.AddAsync(policyType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PolicyTypes.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(PolicyTypeResource resource)
        {
            var policyType = _mapper.Map<PolicyTypeResource, PolicyType>(resource);
            await _unitOfWork.PolicyTypes.DeleteAsync(policyType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PolicyTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PolicyTypes.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<PolicyType>, IEnumerable<PolicyTypeResource>>(result);

            return resources;
        }

        public async Task<PolicyTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PolicyTypes.GetByIdAsync(id);
            var resource = _mapper.Map<PolicyType, PolicyTypeResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(PolicyTypeResource resource)
        {
            var policyType = _mapper.Map<PolicyTypeResource, PolicyType>(resource);
            await _unitOfWork.PolicyTypes.UpdateAsync(resource.Id, policyType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
