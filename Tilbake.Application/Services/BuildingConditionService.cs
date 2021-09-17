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
    public class BuildingConditionService : IBuildingConditionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BuildingConditionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(BuildingConditionSaveResource resource)
        {
            var buildingCondition = _mapper.Map<BuildingConditionSaveResource, BuildingCondition>(resource);
            buildingCondition.Id = Guid.NewGuid();
            buildingCondition.DateAdded = DateTime.Now;

            await _unitOfWork.BuildingConditions.AddAsync(buildingCondition);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.BuildingConditions.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(BuildingConditionResource resource)
        {
            var buildingCondition = _mapper.Map<BuildingConditionResource, BuildingCondition>(resource);
            await _unitOfWork.BuildingConditions.DeleteAsync(buildingCondition);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BuildingConditionResource>> GetAllAsync()
        {
            var result = await _unitOfWork.BuildingConditions.GetAllAsync(
                                                            null,
                                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<BuildingCondition>, IEnumerable<BuildingConditionResource>>(result);
            return resources;
        }

        public async Task<BuildingConditionResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.BuildingConditions.GetByIdAsync(id);
            var resource = _mapper.Map<BuildingCondition, BuildingConditionResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(BuildingConditionResource resource)
        {
            var buildingCondition = _mapper.Map<BuildingConditionResource, BuildingCondition>(resource);
            await _unitOfWork.BuildingConditions.UpdateAsync(resource.Id, buildingCondition);

            return await _unitOfWork.SaveAsync();
        }
    }
}
