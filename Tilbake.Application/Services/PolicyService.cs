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

        public async Task<int> AddAsync(PolicyObjectResource resource)
        {
            var policyRisks = resource.PolicyRisks;
            if (policyRisks == null)
            {
                throw new NullReferenceException(nameof(policyRisks));
            }

            var clientId = resource.ClientId;

            var policy = resource.Policy;
            policy.Id = Guid.NewGuid();
            policy.DateAdded = DateTime.Now;
            await _unitOfWork.Policies.AddAsync(policy);
            var policyId = policy.Id;

            if (resource.AllRisks != null)
            {
                if (resource.RiskItems != null)
                {
                    //  Create RiskItem Record
                    var riskItems = resource.RiskItems;
                    await _unitOfWork.RiskItems.AddRangeAsync(riskItems);

                    //  Update QuoteItems with AllRiskId
                    int ao = resource.AllRisks.Length;
                    var allRisks = resource.AllRisks;
                    await _unitOfWork.AllRisks.AddRangeAsync(allRisks);

                    for (int i = 0; i < ao; i++)
                    {
                        var allRiskId = allRisks[i].Id;

                        Risk risk = new()
                        {
                            Id = Guid.NewGuid(),
                            AllRiskId = allRiskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.Risks.AddAsync(risk);

                        var riskId = risk.Id;

                        ClientRisk clientRisk = new()
                        {
                            Id = Guid.NewGuid(),
                            ClientId = clientId,
                            RiskId = riskId,
                            DateAdded = DateTime.Now
                        };
                        await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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
                await _unitOfWork.Contents.AddRangeAsync(contents);

                for (int i = 0; i < co; i++)
                {
                    var contentId = contents[i].Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        ContentId = contentId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.Risks.AddAsync(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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
                await _unitOfWork.Houses.AddRangeAsync(houses);

                for (int i = 0; i < ho; i++)
                {
                    var houseId = houses[i].Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        HouseId = houseId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.Risks.AddAsync(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk);

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
                await _unitOfWork.Motors.AddRangeAsync(motors);

                for (int i = 0; i < mo; i++)
                {
                    var motorId = motors[i].Id;

                    Risk risk = new()
                    {
                        Id = Guid.NewGuid(),
                        MotorId = motorId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.Risks.AddAsync(risk);

                    var riskId = risk.Id;

                    ClientRisk clientRisk = new()
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        RiskId = riskId,
                        DateAdded = DateTime.Now
                };
                    await _unitOfWork.ClientRisks.AddAsync(clientRisk);

                    var clientRiskId = clientRisk.Id;

                    foreach (var item in policyRisks.Where(x => x.ClientRiskId == motorId))
                    {
                        item.PolicyId = policyId;
                        item.ClientRiskId = clientRiskId;
                        item.DateAdded = DateTime.Now;
                    }
                }
            }

            await _unitOfWork.PolicyRisks.AddRangeAsync(policyRisks);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Policies.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(PolicyResource resource)
        {
            var policy = _mapper.Map<PolicyResource, Policy>(resource);
            await _unitOfWork.Policies.DeleteAsync(policy);
            return await _unitOfWork.SaveAsync();
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
            var result = await _unitOfWork.Policies.GetFirstOrDefaultAsync(
                                        e => e.Id == id,
                                        e => e.Insurer,
                                        e => e.PortfolioClient,
                                        e => e.PaymentMethod,
                                        e => e.PolicyStatus,
                                        e => e.PolicyType,
                                        e => e.SalesType);
            var resources = _mapper.Map<Policy, PolicyResource>(result);

            return resources;
        }

        public async Task<IEnumerable<PolicyResource>> GetByPorfolioClientIdAsync(Guid portfolioClientId)
        {
            var result = await _unitOfWork.Policies.GetAllAsync(
                                            e => e.PortfolioClientId == portfolioClientId,
                                            e => e.OrderByDescending(r => r.CoverStartDate),
                                            p => p.PaymentMethod,
                                            p => p.PolicyStatus,
                                            p => p.PolicyType,
                                            p => p.SalesType,
                                            p => p.Insurer,
                                            e => e.PortfolioClient);

            var resources = _mapper.Map<IEnumerable<Policy>, IEnumerable<PolicyResource>>(result);

            return resources;
        }

        public async Task<PolicyResource> GetCurrentPolicyAsync(Guid portfolioClientId)
        {
            var result = await _unitOfWork.Policies.GetFirstOrDefaultAsync(
                                             e => e.PortfolioClientId == portfolioClientId,
                                             p => p.PaymentMethod,
                                             p => p.PolicyStatus,
                                             p => p.PolicyType,
                                             p => p.SalesType,
                                             p => p.Insurer,
                                             e => e.PortfolioClient);

            var resource = _mapper.Map<Policy, PolicyResource>(result);
            return resource;
        }

        public async Task<int> QuoteToPolicy(QuotePolicyObjectResource resource)
        {
            var insurerId = resource.Quote.InsurerId;

            var portfolioClientId = resource.Quote.PortfolioClientId;

            var quote = _mapper.Map<QuoteResource, Quote>(resource.Quote);
            var policy = _mapper.Map<PolicySaveResource, Policy>(resource.Policy);

            policy.Id = Guid.NewGuid();
            policy.InsurerId = insurerId;
            policy.PortfolioClientId = portfolioClientId;
            policy.DateAdded = DateTime.Now;
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
                    Description = item.Description,
                    DateAdded = DateTime.Now
            };
                policyRisks.Add(policyRisk);
            }
            await _unitOfWork.PolicyRisks.AddRangeAsync(policyRisks);

            quote.IsPolicySet = true;
            await _unitOfWork.Quotes.UpdateAsync(quote.Id, quote);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdateAsync(PolicyResource resource)
        {
            var policy = _mapper.Map<PolicyResource, Policy>(resource);
            await _unitOfWork.Policies.UpdateAsync(resource.Id, policy);

            return await _unitOfWork.SaveAsync();
        }
    }
}
