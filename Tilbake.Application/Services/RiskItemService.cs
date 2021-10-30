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
    public class RiskItemService : IRiskItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RiskItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(RiskItemSaveResource resource)
        {
            var riskItem = _mapper.Map<RiskItemSaveResource, RiskItem>(resource);
            riskItem.Id = Guid.NewGuid();

            _unitOfWork.RiskItems.Add(riskItem);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.RiskItems.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<RiskItemResource>> GetAllAsync()
        {
            var result = await _unitOfWork.RiskItems.FindAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Description));

            var resources = _mapper.Map<IEnumerable<RiskItem>, IEnumerable<RiskItemResource>>(result);

            return resources;
        }

        public async Task<RiskItemResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RiskItems.GetByIdAsync(id);
            var resource = _mapper.Map<RiskItem, RiskItemResource>(result);
            return resource;
        }

        public async void Update(RiskItemResource resource)
        {
            var riskItem = _mapper.Map<RiskItemResource, RiskItem>(resource);
            _unitOfWork.RiskItems.Update(resource.Id, riskItem);

            await _unitOfWork.SaveAsync();
        }
    }
}
