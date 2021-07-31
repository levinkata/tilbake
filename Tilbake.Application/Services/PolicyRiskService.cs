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
    public class PolicyRiskService : IPolicyRiskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PolicyRiskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PolicyRiskSaveResource resource)
        {
            var policyRisk = _mapper.Map<PolicyRiskSaveResource, PolicyRisk>(resource);
            policyRisk.Id = Guid.NewGuid();

            await _unitOfWork.PolicyRisks.AddAsync(policyRisk);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PolicyRisks.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(PolicyRiskResource resource)
        {
            var policyRisk = _mapper.Map<PolicyRiskResource, PolicyRisk>(resource);
            await _unitOfWork.PolicyRisks.DeleteAsync(policyRisk);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<PolicyRiskResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.PolicyRisks.GetAllAsync());
            var resources = _mapper.Map<IEnumerable<PolicyRisk>, IEnumerable<PolicyRiskResource>>(result);

            return resources;
        }

        public async Task<PolicyRiskResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PolicyRisks.GetByIdAsync(id);
            var resources = _mapper.Map<PolicyRisk, PolicyRiskResource>(result);

            return resources;
        }

        public async Task<IEnumerable<PolicyRiskResource>> GetByPolicyIdAsync(Guid policyId)
        {
            var result = await Task.Run(() => _unitOfWork.PolicyRisks.GetAsync(x => x.PolicyId == policyId));
            var resources = _mapper.Map<IEnumerable<PolicyRisk>, IEnumerable<PolicyRiskResource>>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(PolicyRiskResource resource)
        {
            var policyRisk = _mapper.Map<PolicyRiskResource, PolicyRisk>(resource);
            await _unitOfWork.PolicyRisks.UpdateAsync(resource.Id, policyRisk);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
