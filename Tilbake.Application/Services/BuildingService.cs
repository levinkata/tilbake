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
    public class BuildingService : IBuildingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BuildingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(BuildingSaveResource resource)
        {
            var building = _mapper.Map<BuildingSaveResource, Building>(resource);
            building.Id = Guid.NewGuid();
            building.DateAdded = DateTime.Now;

            _unitOfWork.Buildings.Add(building);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.Buildings.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BuildingResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Buildings.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.PhysicalAddress),
                                            r => r.BuildingCondition,
                                            r => r.ResidenceType,
                                            r => r.ResidenceUse,
                                            r => r.RoofType,
                                            r => r.WallType);

            var resources = _mapper.Map<IEnumerable<Building>, IEnumerable<BuildingResource>>(result);
            return resources;
        }

        public async Task<BuildingResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Buildings.GetAsync(
                                            r => r.Id == id,
                                            r => r.OrderBy(n => n.PhysicalAddress),
                                            r => r.BuildingCondition,
                                            r => r.ResidenceType,
                                            r => r.ResidenceUse,
                                            r => r.RoofType,
                                            r => r.WallType);

            var resource = _mapper.Map<Building, BuildingResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(BuildingResource resource)
        {
            var building = _mapper.Map<BuildingResource, Building>(resource);
            _unitOfWork.Buildings.Update(resource.Id, building);

            return await _unitOfWork.SaveAsync();
        }
    }
}
