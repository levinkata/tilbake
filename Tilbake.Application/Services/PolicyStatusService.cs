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
    public class PolicyStatusService : IPolicyStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PolicyStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(PolicyStatusSaveResource resource)
        {
            var policyStatus = _mapper.Map<PolicyStatusSaveResource, PolicyStatus>(resource);
            policyStatus.Id = Guid.NewGuid();

            _unitOfWork.PolicyStatuses.Add(policyStatus);
            _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.PolicyStatuses.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PolicyStatusResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PolicyStatuses.FindAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<PolicyStatus>, IEnumerable<PolicyStatusResource>>(result);
            return resources;
        }

        public async Task<PolicyStatusResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PolicyStatuses.GetByIdAsync(id);
            var resource = _mapper.Map<PolicyStatus, PolicyStatusResource>(result);
            return resource;
        }

        public async void Update(PolicyStatusResource resource)
        {
            var policyStatus = _mapper.Map<PolicyStatusResource, PolicyStatus>(resource);
            _unitOfWork.PolicyStatuses.Update(resource.Id, policyStatus);

            _unitOfWork.SaveAsync();
        }
    }
}
