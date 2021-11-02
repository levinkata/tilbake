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

            _unitOfWork.BuildingConditions.Add(buildingCondition);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.BuildingConditions.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BuildingConditionResource>> GetAllAsync()
        {
            var result = await _unitOfWork.BuildingConditions.GetAsync(
                                                            null,
                                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<BuildingCondition>, IEnumerable<BuildingConditionResource>>(result);
            return resources;
        }

        public async Task<BuildingConditionResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.BuildingConditions.GetAsync(
                                                            r => r.Id == id,
                                                            r => r.OrderBy(n => n.Name));
            var resource = _mapper.Map<BuildingCondition, BuildingConditionResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(BuildingConditionResource resource)
        {
            var buildingCondition = _mapper.Map<BuildingConditionResource, BuildingCondition>(resource);
            _unitOfWork.BuildingConditions.Update(resource.Id, buildingCondition);

            return await _unitOfWork.SaveAsync();
        }
    }
}
