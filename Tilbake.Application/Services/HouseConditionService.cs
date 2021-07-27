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

            await _unitOfWork.HouseConditions.AddAsync(houseCondition).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.HouseConditions.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(HouseConditionResource resource)
        {
            var houseCondition = _mapper.Map<HouseConditionResource, HouseCondition>(resource);
            await _unitOfWork.HouseConditions.DeleteAsync(houseCondition).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<HouseConditionResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.HouseConditions.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<HouseCondition>, IEnumerable<HouseConditionResource>>(result);

            return resources;
        }

        public async Task<HouseConditionResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.HouseConditions.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<HouseCondition, HouseConditionResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(HouseConditionResource resource)
        {
            var houseCondition = _mapper.Map<HouseConditionResource, HouseCondition>(resource);
            await _unitOfWork.HouseConditions.UpdateAsync(resource.Id, houseCondition).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
