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

        public async void Delete(Guid id)
        {
            _unitOfWork.QuoteItems.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<QuoteItemResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.QuoteItems.GetFirstOrDefaultAsync(
                                            p => p.Id == id,
                                            p => p.CoverType,
                                            p => p.Quote);

            var resource = _mapper.Map<QuoteItem, QuoteItemResource>(result);
            return resource;
        }

        public async Task<IEnumerable<QuoteItemResource>> GetByQuoteIdAsync(Guid quoteId)
        {
            var result = await _unitOfWork.QuoteItems.GetAllAsync(
                                            p => p.QuoteId == quoteId,
                                            p => p.OrderBy(n => n.Description),
                                            p => p.CoverType,
                                            p => p.Quote);

            var resources = _mapper.Map<IEnumerable<QuoteItem>, IEnumerable<QuoteItemResource>>(result);
            return resources;
        }

        public async Task<QuoteItemObjectResource> GetRisksAsync(Guid id)
        {
            var resultAllRisk = await _unitOfWork.QuoteItems.GetAllRiskAsync(id);
            var resultBuilding = await _unitOfWork.QuoteItems.GetBuildingAsync(id);
            var resultContent = await _unitOfWork.QuoteItems.GetContentAsync(id);
            var resultExcessBuyBack = await _unitOfWork.QuoteItems.GetExcessBuyBackAsync(id);
            var resultHouse = await _unitOfWork.QuoteItems.GetHouseAsync(id);
            var resultMotor = await _unitOfWork.QuoteItems.GetMotorAsync(id);

            var resourceAllRisk = _mapper.Map<AllRisk, AllRiskResource>(resultAllRisk);
            var resourceBuilding = _mapper.Map<Building, BuildingResource>(resultBuilding);
            var resourceContent = _mapper.Map<Content, ContentResource>(resultContent);
            var resourceExcessBuyBack = _mapper.Map<ExcessBuyBack, ExcessBuyBackResource>(resultExcessBuyBack);
            var resourceHouse = _mapper.Map<House, HouseResource>(resultHouse);
            var resourceMotor = _mapper.Map<Motor, MotorResource>(resultMotor);

            QuoteItemObjectResource quoteItemObjectResource = new()
            {
                AllRisk = resourceAllRisk,
                Building = resourceBuilding,
                Content = resourceContent,
                ExcessBuyBack = resourceExcessBuyBack,
                House = resourceHouse,
                Motor = resourceMotor
            };

            return quoteItemObjectResource;
        }

        public async void Update(QuoteItemResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource);

            var taxes = await _unitOfWork.Taxes.GetAllAsync(
                                            null,
                                            r => r.OrderByDescending(n => n.TaxDate));

            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            quoteItem.DateModified = DateTime.Now;
            quoteItem.TaxRate = taxRate;
            quoteItem.TaxAmount = quoteItem.Premium - (quoteItem.Premium / (1 + taxRate / 100));

            _unitOfWork.QuoteItems.Update(resource.Id, quoteItem);

            await _unitOfWork.SaveAsync();
        }

        public async void UpdateQuoteItemRiskItem(QuoteItemRiskItemResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);

            var taxes = await _unitOfWork.Taxes.GetAllAsync(
                                            null,
                                            r => r.OrderByDescending(n => n.TaxDate));

            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            quoteItem.DateModified = DateTime.Now;
            quoteItem.TaxRate = taxRate;
            quoteItem.TaxAmount = quoteItem.Premium - (quoteItem.Premium / (1 + taxRate / 100));

            _unitOfWork.QuoteItems.Update(resource.QuoteItem.Id, quoteItem);

            var riskItem = _mapper.Map<RiskItemResource, RiskItem>(resource.RiskItem);
            _unitOfWork.RiskItems.Update(resource.RiskItem.Id, riskItem);

            await _unitOfWork.SaveAsync();
        }

        public async void UpdateQuoteItemBuilding(QuoteItemBuildingResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);
            _unitOfWork.QuoteItems.Update(resource.QuoteItem.Id, quoteItem);

            var building = _mapper.Map<BuildingResource, Building>(resource.Building);
            _unitOfWork.Buildings.Update(resource.Building.Id, building);

            await _unitOfWork.SaveAsync();
        }

        public async void UpdateQuoteItemContent(QuoteItemContentResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);
            _unitOfWork.QuoteItems.Update(resource.QuoteItem.Id, quoteItem);

            var content = _mapper.Map<ContentResource, Content>(resource.Content);
            _unitOfWork.Contents.Update(resource.Content.Id, content);

            await _unitOfWork.SaveAsync();
        }

        public async void UpdateQuoteItemHouse(QuoteItemHouseResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);
            _unitOfWork.QuoteItems.Update(resource.QuoteItem.Id, quoteItem);

            var house = _mapper.Map<HouseResource, House>(resource.House);
            _unitOfWork.Houses.Update(resource.House.Id, house);

            await _unitOfWork.SaveAsync();
        }

        public async void UpdateQuoteItemMotor(QuoteItemMotorResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);
            _unitOfWork.QuoteItems.Update(resource.QuoteItem.Id, quoteItem);

            var motor = _mapper.Map<MotorResource, Motor>(resource.Motor);
            _unitOfWork.Motors.Update(resource.Motor.Id, motor);

            await _unitOfWork.SaveAsync();
        }

        public async void UpdateQuoteItemExcessBuyBack(QuoteItemExcessBuyBackResource resource)
        {
            var quoteItem = _mapper.Map<QuoteItemResource, QuoteItem>(resource.QuoteItem);
            _unitOfWork.QuoteItems.Update(resource.QuoteItem.Id, quoteItem);

            var motor = _mapper.Map<ExcessBuyBackResource, ExcessBuyBack>(resource.ExcessBuyBack);
            _unitOfWork.ExcessBuyBacks.Update(resource.ExcessBuyBack.Id, motor);

            await _unitOfWork.SaveAsync();
        }
    }
}
