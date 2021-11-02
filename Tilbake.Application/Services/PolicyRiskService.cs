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
            policyRisk.DateAdded = DateTime.Now;

            _unitOfWork.PolicyRisks.Add(policyRisk);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.PolicyRisks.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PolicyRiskResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PolicyRisks.GetAsync(null);
            var resources = _mapper.Map<IEnumerable<PolicyRisk>, IEnumerable<PolicyRiskResource>>(result);
            return resources;
        }

        public async Task<PolicyRiskResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PolicyRisks.GetByIdAsync(id);
            var resource = _mapper.Map<PolicyRisk, PolicyRiskResource>(result);
            return resource;
        }

        public async Task<IEnumerable<PolicyRiskResource>> GetByPolicyIdAsync(Guid policyId)
        {
            var result = await _unitOfWork.PolicyRisks.GetAsync(
                                            e => e.PolicyId == policyId,
                                            e => e.OrderByDescending(r => r.RiskDate),
                                            p => p.CoverType);

            var resources = _mapper.Map<IEnumerable<PolicyRisk>, IEnumerable<PolicyRiskResource>>(result);
            return resources;
        }

        public async Task<decimal> GetPremiumByPortfolioClientIdAsync(Guid portfolioClientId)
        {
            var result = await _unitOfWork.PolicyRisks.GetAsync(
                                            e => e.Policy.PortfolioClientId == portfolioClientId);
                                            
            return result.Sum(r => r.Premium);
        }

        public async Task<PolicyRiskObjectResource> GetRisksAsync(Guid id)
        {
            var resultAllRisk = await _unitOfWork.PolicyRisks.GetAllRiskAsync(id);
            var resultBuilding = await _unitOfWork.PolicyRisks.GetBuildingAsync(id);
            var resultContent = await _unitOfWork.PolicyRisks.GetContentAsync(id);
            var resultHouse = await _unitOfWork.PolicyRisks.GetHouseAsync(id);
            var resultMotor = await _unitOfWork.PolicyRisks.GetMotorAsync(id);

            var resourceAllRisk = _mapper.Map<AllRisk, AllRiskResource>(resultAllRisk);
            var resourceBuilding = _mapper.Map<Building, BuildingResource>(resultBuilding);
            var resourceContent = _mapper.Map<Content, ContentResource>(resultContent);
            var resourceHouse = _mapper.Map<House, HouseResource>(resultHouse);
            var resourceMotor = _mapper.Map<Motor, MotorResource>(resultMotor);

            PolicyRiskObjectResource policyRiskObjectResource = new()
            {
                AllRisk = resourceAllRisk,
                Building = resourceBuilding,
                Content = resourceContent,
                House = resourceHouse,
                Motor = resourceMotor
            };

            return policyRiskObjectResource;
        }

        public async Task<decimal> GetSumInsuredByPortfolioClientIdAsync(Guid portfolioClientId)
        {
            var result = await _unitOfWork.PolicyRisks.GetAsync(
                                            e => e.Policy.PortfolioClientId == portfolioClientId);

            return result.Sum(r => r.SumInsured);
        }

        public async Task<int> UpdateAsync(PolicyRiskResource resource)
        {
            var policyRisk = _mapper.Map<PolicyRiskResource, PolicyRisk>(resource);
            policyRisk.DateModified = DateTime.Now;

            _unitOfWork.PolicyRisks.Update(resource.Id, policyRisk);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdatePolicyRiskBuilding(PolicyRiskBuildingResource resource)
        {
            var policyRisk = _mapper.Map<PolicyRiskResource, PolicyRisk>(resource.PolicyRisk);
            _unitOfWork.PolicyRisks.Update(resource.PolicyRisk.Id, policyRisk);

            var building = _mapper.Map<BuildingResource, Building>(resource.Building);
            _unitOfWork.Buildings.Update(resource.Building.Id, building);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdatePolicyRiskContent(PolicyRiskContentResource resource)
        {
            var policyRisk = _mapper.Map<PolicyRiskResource, PolicyRisk>(resource.PolicyRisk);
            _unitOfWork.PolicyRisks.Update(resource.PolicyRisk.Id, policyRisk);

            var content = _mapper.Map<ContentResource, Content>(resource.Content);
            _unitOfWork.Contents.Update(resource.Content.Id, content);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdatePolicyRiskHouse(PolicyRiskHouseResource resource)
        {
            var policyRisk = _mapper.Map<PolicyRiskResource, PolicyRisk>(resource.PolicyRisk);
            _unitOfWork.PolicyRisks.Update(resource.PolicyRisk.Id, policyRisk);

            var house = _mapper.Map<HouseResource, House>(resource.House);
            _unitOfWork.Houses.Update(resource.House.Id, house);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdatePolicyRiskMotor(PolicyRiskMotorResource resource)
        {
            var policyRisk = _mapper.Map<PolicyRiskResource, PolicyRisk>(resource.PolicyRisk);
            _unitOfWork.PolicyRisks.Update(resource.PolicyRisk.Id, policyRisk);

            var motor = _mapper.Map<MotorResource, Motor>(resource.Motor);
            _unitOfWork.Motors.Update(resource.Motor.Id, motor);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdatePolicyRiskRiskItem(PolicyRiskRiskItemResource resource)
        {
            var policyRisk = _mapper.Map<PolicyRiskResource, PolicyRisk>(resource.PolicyRisk);
            _unitOfWork.PolicyRisks.Update(resource.PolicyRisk.Id, policyRisk);

            var riskItem = _mapper.Map<RiskItemResource, RiskItem>(resource.RiskItem);
            _unitOfWork.RiskItems.Update(resource.RiskItem.Id, riskItem);

            return await _unitOfWork.SaveAsync();
        }
    }
}
