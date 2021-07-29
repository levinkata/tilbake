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
    public class PolicyService : IPolicyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PolicyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PolicySaveResource resource)
        {
            var policy = _mapper.Map<PolicySaveResource, Policy>(resource);
            policy.Id = Guid.NewGuid();

            await _unitOfWork.Policies.AddAsync(policy);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Policies.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(PolicyResource resource)
        {
            var policy = _mapper.Map<PolicyResource, Policy>(resource);
            await _unitOfWork.Policies.DeleteAsync(policy);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<PolicyResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Policies.GetAllAsync());
            result = result.OrderBy(n => n.PolicyNumber);

            var resources = _mapper.Map<IEnumerable<Policy>, IEnumerable<PolicyResource>>(result);

            return resources;
        }

        public async Task<PolicyResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Policies.GetByIdAsync(id);
            var resources = _mapper.Map<Policy, PolicyResource>(result);

            return resources;
        }

        public async Task<int> QuoteToPolicy(QuotePolicyObjectResource resource)
        {
            var insurerId = resource.Quote.InsurerId;
            var portfolioClientId = resource.Quote.PortfolioClientId;

            var policy = _mapper.Map<PolicySaveResource, Policy>(resource.Policy);

            policy.Id = Guid.NewGuid();
            policy.InsurerId = insurerId;
            policy.PortfolioClientId = portfolioClientId;
            await _unitOfWork.Policies.AddAsync(policy);

            var policyId = policy.Id;

            List<PolicyRisk> policyRisks = new();

            foreach (QuoteItemResource item in resource.QuoteItems)
            {
                PolicyRisk policyRisk = new()
                {
                    Id = Guid.NewGuid(),
                    PolicyId = policyId,
                    ClientRiskId = item.ClientRiskId,
                    CoverTypeId = item.CoverTypeId,
                    RiskDate = DateTime.Now,
                    SumInsured = item.SumInsured,
                    Premium = item.Premium,
                    Excess = item.Excess,
                    Description = item.Description
                };
                policyRisks.Add(policyRisk);
            }
            await _unitOfWork.PolicyRisks.AddRangeAsync(policyRisks);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> UpdateAsync(PolicyResource resource)
        {
            var policy = _mapper.Map<PolicyResource, Policy>(resource);
            await _unitOfWork.Policies.UpdateAsync(resource.Id, policy);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
