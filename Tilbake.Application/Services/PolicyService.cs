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
    public class PolicyService : IPolicyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PolicyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PolicyObjectResource resource)
        {
            var policyRisks = resource.PolicyRisks;

            var clientId = resource.ClientId;

            var policy = resource.Policy;
            policy.Id = Guid.NewGuid();
            policy.DateAdded = DateTime.Now;
            _unitOfWork.Policies.Add(policy);
            var policyId = policy.Id;

            if (resource.AllRisks != null)
            {
                if (resource.RiskItems != null)
                {
                    //  Create RiskItem Record
                    var riskItems = resource.RiskItems;
                    _unitOfWork.RiskItems.AddRange(riskItems);

                    //  Update QuoteItems with AllRiskId
                    int ao = resource.AllRisks.Length;
                    var allRisks = resource.AllRisks;
                    _unitOfWork.AllRisks.AddRange(allRisks);

                    for (int i = 0; i < ao; i++)
                    {
                        var allRiskId = allRisks[i].Id;

                        Risk risk = new()
                        {
                            Id = Guid.NewGuid(),
                            AllRiskId = allRiskId,
                            DateAdded = DateTime.Now
                        };
                        _unitOfWork.Risks.Add(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        _unitOfWork.ClientRisks.Add(clientRisk);

                        var clientRiskId = clientRisk.Id;

                        foreach (var item in policyRisks.Where(x => x.ClientRiskId == allRiskId))
                        {
                            item.PolicyId = policyId;
                            item.ClientRiskId = clientRiskId;
                            item.DateAdded = DateTime.Now;
                        }
                    }
                }
            }

            if (resource.Contents != null)
            {
                //  Update QuoteItems with ContentId
                int co = resource.Contents.Length;
                var contents = resource.Contents;
                _unitOfWork.Contents.AddRange(contents);

                for (int i = 0; i < co; i++)
                {
                    var contentId = contents[i].Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        ContentId = contentId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.Risks.Add(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.ClientRisks.Add(clientRisk);

                    var clientRiskId = clientRisk.Id;

                    foreach (var item in policyRisks.Where(x => x.ClientRiskId == contentId))
                    {
                        item.PolicyId = policyId;
                        item.ClientRiskId = clientRiskId;
                        item.DateAdded = DateTime.Now;
                    }
                }
            }

            if (resource.Houses != null)
            {
                //  Update QuoteItems with HouseId
                int ho = resource.Houses.Length;
                var houses = resource.Houses;
                _unitOfWork.Houses.AddRange(houses);

                for (int i = 0; i < ho; i++)
                {
                    var houseId = houses[i].Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        HouseId = houseId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.Risks.Add(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.ClientRisks.Add(clientRisk);

                    var clientRiskId = clientRisk.Id;

                    foreach (var item in policyRisks.Where(x => x.ClientRiskId == houseId))
                    {
                        item.PolicyId = policyId;
                        item.ClientRiskId = clientRiskId;
                        item.DateAdded = DateTime.Now;
                    }
                }
            }

            if (resource.Motors != null)
            {
                //  Update QuoteItems with MotorId
                int mo = resource.Motors.Length;
                var motors = resource.Motors;
                _unitOfWork.Motors.AddRange(motors);

                for (int i = 0; i < mo; i++)
                {
                    var motorId = motors[i].Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        MotorId = motorId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.Risks.Add(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                };
                    _unitOfWork.ClientRisks.Add(clientRisk);

                    var clientRiskId = clientRisk.Id;

                    foreach (var item in policyRisks.Where(x => x.ClientRiskId == motorId))
                    {
                        item.PolicyId = policyId;
                        item.ClientRiskId = clientRiskId;
                        item.DateAdded = DateTime.Now;
                    }
                }
            }

            _unitOfWork.PolicyRisks.AddRange(policyRisks);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.Policies.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PolicyResource>> GetAllAsync(Guid portfolioClientId)
        {
            var result = await _unitOfWork.Policies.GetAsync(
                                        e => e.PortfolioClientId == portfolioClientId,
                                        e => e.OrderByDescending(n => n.PolicyNumber),
                                        e => e.InsurerBranch,
                                        e => e.InsurerBranch.Insurer,
                                        e => e.PortfolioClient,
                                        e => e.PaymentMethod,
                                        e => e.PolicyStatus,
                                        e => e.PolicyType,
                                        e => e.SalesType);

            //  Skip top record as this is collecting historical policies
            //result = result.Skip(1);
            
            var resources = _mapper.Map<IEnumerable<Policy>, IEnumerable<PolicyResource>>(result);

            //  Skip top record as this is collecting historical policies
            return resources.Skip(1);
        }

        public async Task<PolicyResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Policies.GetAsync(
                                        e => e.Id == id,
                                        null,
                                        e => e.InsurerBranch,
                                        e => e.InsurerBranch.Insurer,
                                        e => e.PortfolioClient,
                                        e => e.PaymentMethod,
                                        e => e.PolicyStatus,
                                        e => e.PolicyType,
                                        e => e.SalesType);

            var resource = _mapper.Map<Policy, PolicyResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<IEnumerable<PolicyResource>> GetByPorfolioClientIdAsync(Guid portfolioClientId)
        {
            var result = await _unitOfWork.Policies.GetAsync(
                                            e => e.PortfolioClientId == portfolioClientId,
                                            e => e.OrderByDescending(r => r.CoverStartDate),
                                            p => p.PaymentMethod,
                                            p => p.PolicyStatus,
                                            p => p.PolicyType,
                                            p => p.SalesType,
                                            p => p.InsurerBranch,
                                            p => p.InsurerBranch.Insurer,
                                            e => e.PortfolioClient);

            var resources = _mapper.Map<IEnumerable<Policy>, IEnumerable<PolicyResource>>(result);
            return resources;
        }

        public async Task<PolicyResource> GetCurrentPolicyAsync(Guid portfolioClientId)
        {
            var result = await _unitOfWork.Policies.GetAsync(
                                             e => e.PortfolioClientId == portfolioClientId,
                                             null,
                                             p => p.PaymentMethod,
                                             p => p.PolicyStatus,
                                             p => p.PolicyType,
                                             p => p.SalesType,
                                             p => p.InsurerBranch,
                                             p => p.InsurerBranch.Insurer,
                                             p => p.PortfolioClient);

            var resource = _mapper.Map<Policy, PolicyResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> QuoteToPolicy(QuotePolicyObjectResource resource)
        {
            var insurerBranchId = resource.Quote.InsurerBranchId;

            var portfolioClientId = resource.Quote.PortfolioClientId;

            var quote = _mapper.Map<QuoteResource, Quote>(resource.Quote);
            var policy = _mapper.Map<PolicySaveResource, Policy>(resource.Policy);

            policy.Id = Guid.NewGuid();
            policy.InsurerBranchId = insurerBranchId;
            policy.PortfolioClientId = portfolioClientId;
            policy.DateAdded = DateTime.Now;
            _unitOfWork.Policies.Add(policy);

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
                    Description = item.Description,
                    DateAdded = DateTime.Now
            };
                policyRisks.Add(policyRisk);
            }
            _unitOfWork.PolicyRisks.AddRange(policyRisks);

            quote.IsPolicySet = true;
            _unitOfWork.Quotes.Update(quote.Id, quote);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdateAsync(PolicyResource resource)
        {
            var policy = _mapper.Map<PolicyResource, Policy>(resource);
             _unitOfWork.Policies.Update(resource.Id, policy);

            return await _unitOfWork.SaveAsync();
        }
    }
}
