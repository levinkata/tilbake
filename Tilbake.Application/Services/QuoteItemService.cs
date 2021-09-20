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
    public class QuoteItemService : IQuoteItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuoteItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.QuoteItems.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<QuoteItemResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.QuoteItems.GetByIdAsync(id);
            var resource = _mapper.Map<QuoteItem, QuoteItemResource>(result);
            return resource;
        }

        public async Task<IEnumerable<QuoteItemResource>> GetByQuoteIdAsync(Guid quoteId)
        {
            var result = await Task.Run(() => _unitOfWork.QuoteItems.GetByQuoteIdAsync(quoteId));
            var resources = _mapper.Map<IEnumerable<QuoteItem>, IEnumerable<QuoteItemResource>>(result);
            
            return resources;
        }

        public async Task<QuoteItemResource> GetFirstOrDefaultAsync(Guid id)
        {
            var result = await _unitOfWork.QuoteItems.GetFirstOrDefaultAsync(p => p.Id == id, p => p.CoverType);
            var resource = _mapper.Map<QuoteItem, QuoteItemResource>(result);

            return resource;
        }

        public async Task<QuoteItemObjectResource> GetRisksAsync(Guid id)
        {
            var resultAllRisk = await _unitOfWork.QuoteItems.GetAllRiskAsync(id);
            var resultBuilding = await _unitOfWork.QuoteItems.GetBuildingAsync(id);
            var resultContent = await _unitOfWork.QuoteItems.GetContentAsync(id);
            var resultHouse = await _unitOfWork.QuoteItems.GetHouseAsync(id);
            var resultMotor = await _unitOfWork.QuoteItems.GetMotorAsync(id);

            var resourceAllRisk = _mapper.Map<AllRisk, AllRiskResource>(resultAllRisk);
            var resourceBuilding = _mapper.Map<Building, BuildingResource>(resultBuilding);
            var resourceContent = _mapper.Map<Content, ContentResource>(resultContent);
            var resourceHouse = _mapper.Map<House, HouseResource>(resultHouse);
            var resourceMotor = _mapper.Map<Motor, MotorResource>(resultMotor);

            QuoteItemObjectResource quoteItemObjectResource = new()
            {
                AllRisk = resourceAllRisk,
                Building = resourceBuilding,
                Content = resourceContent,
                House = resourceHouse,
                Motor = resourceMotor
            };

            return quoteItemObjectResource;
        }

        public async Task<int> UpdateAsync(QuoteItemResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource);

            var taxes = await _unitOfWork.Taxes.GetAllAsync(
                                            null,
                                            r => r.OrderByDescending(n => n.TaxDate));

            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            quoteItem.DateModified = DateTime.Now;
            quoteItem.TaxRate = taxRate;
            quoteItem.TaxAmount = quoteItem.Premium * taxRate / 100;

            await _unitOfWork.QuoteItems.UpdateAsync(resource.Id, quoteItem);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdateQuoteItemRiskItemAsync(QuoteItemRiskItemResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);

            var taxes = await _unitOfWork.Taxes.GetAllAsync(
                                            null,
                                            r => r.OrderByDescending(n => n.TaxDate));

            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            quoteItem.DateModified = DateTime.Now;
            quoteItem.TaxRate = taxRate;
            quoteItem.TaxAmount = quoteItem.Premium * taxRate / 100;

            await _unitOfWork.QuoteItems.UpdateAsync(resource.QuoteItem.Id, quoteItem);

            var riskItem = _mapper.Map<RiskItemResource, RiskItem>(resource.RiskItem);
            await _unitOfWork.RiskItems.UpdateAsync(resource.RiskItem.Id, riskItem);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdateQuoteItemBuildingAsync(QuoteItemBuildingResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);
            await _unitOfWork.QuoteItems.UpdateAsync(resource.QuoteItem.Id, quoteItem);

            var building = _mapper.Map<BuildingResource, Building>(resource.Building);
            await _unitOfWork.Buildings.UpdateAsync(resource.Building.Id, building);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdateQuoteItemContentAsync(QuoteItemContentResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);
            await _unitOfWork.QuoteItems.UpdateAsync(resource.QuoteItem.Id, quoteItem);

            var content = _mapper.Map<ContentResource, Content>(resource.Content);
            await _unitOfWork.Contents.UpdateAsync(resource.Content.Id, content);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdateQuoteItemHouseAsync(QuoteItemHouseResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);
            await _unitOfWork.QuoteItems.UpdateAsync(resource.QuoteItem.Id, quoteItem);

            var house = _mapper.Map<HouseResource, House>(resource.House);
            await _unitOfWork.Houses.UpdateAsync(resource.House.Id, house);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdateQuoteItemMotorAsync(QuoteItemMotorResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);
            await _unitOfWork.QuoteItems.UpdateAsync(resource.QuoteItem.Id, quoteItem);

            var motor = _mapper.Map<MotorResource, Motor>(resource.Motor);
            await _unitOfWork.Motors.UpdateAsync(resource.Motor.Id, motor);

            return await _unitOfWork.SaveAsync();
        }
    }
}
