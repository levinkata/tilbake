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
    public class HouseConditionService : IHouseConditionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HouseConditionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(HouseConditionSaveResource resource)
        {
            var houseCondition = _mapper.Map<HouseConditionSaveResource, HouseCondition>(resource);
            houseCondition.Id = Guid.NewGuid();

            _unitOfWork.HouseConditions.Add(houseCondition);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.HouseConditions.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<HouseConditionResource>> GetAllAsync()
        {
            var result = await _unitOfWork.HouseConditions.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<HouseCondition>, IEnumerable<HouseConditionResource>>(result);
            return resources;
        }

        public async Task<HouseConditionResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.HouseConditions.GetByIdAsync(id);
            var resource = _mapper.Map<HouseCondition, HouseConditionResource>(result);
            return resource;
        }

        public async void Update(HouseConditionResource resource)
        {
            var houseCondition = _mapper.Map<HouseConditionResource, HouseCondition>(resource);
            _unitOfWork.HouseConditions.Update(resource.Id, houseCondition);

            await _unitOfWork.SaveAsync();
        }
    }
}
