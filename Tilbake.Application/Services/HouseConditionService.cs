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

        public async Task<int> AddAsync(HouseConditionSaveResource resource)
        {
            var houseCondition = _mapper.Map<HouseConditionSaveResource, HouseCondition>(resource);
            houseCondition.Id = Guid.NewGuid();

            await _unitOfWork.HouseConditions.AddAsync(houseCondition);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.HouseConditions.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(HouseConditionResource resource)
        {
            var houseCondition = _mapper.Map<HouseConditionResource, HouseCondition>(resource);
            await _unitOfWork.HouseConditions.DeleteAsync(houseCondition);

            return await _unitOfWork.SaveAsync();
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

        public async Task<int> UpdateAsync(HouseConditionResource resource)
        {
            var houseCondition = _mapper.Map<HouseConditionResource, HouseCondition>(resource);
            await _unitOfWork.HouseConditions.UpdateAsync(resource.Id, houseCondition);

            return await _unitOfWork.SaveAsync();
        }
    }
}
