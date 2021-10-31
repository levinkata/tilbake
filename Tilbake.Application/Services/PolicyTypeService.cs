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
    public class PolicyTypeService : IPolicyTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PolicyTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(PolicyTypeSaveResource resource)
        {
            var policyType = _mapper.Map<PolicyTypeSaveResource, PolicyType>(resource);
            policyType.Id = Guid.NewGuid();

            _unitOfWork.PolicyTypes.Add(policyType);
            _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.PolicyTypes.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PolicyTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PolicyTypes.FindAllAsync(
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

        public async void Update(PolicyTypeResource resource)
        {
            var policyType = _mapper.Map<PolicyTypeResource, PolicyType>(resource);
            _unitOfWork.PolicyTypes.Update(resource.Id, policyType);

            _unitOfWork.SaveAsync();
        }
    }
}
