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

            await _unitOfWork.Buildings.AddAsync(building);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Buildings.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(BuildingResource resource)
        {
            var building = _mapper.Map<BuildingResource, Building>(resource);
            await _unitOfWork.Buildings.DeleteAsync(building);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BuildingResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Buildings.GetAllAsync(
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
            var result = await _unitOfWork.Buildings.GetFirstOrDefaultAsync(
                                            r => r.Id == id,
                                            r => r.BuildingCondition,
                                            r => r.ResidenceType,
                                            r => r.ResidenceUse,
                                            r => r.RoofType,
                                            r => r.WallType);

            var resource = _mapper.Map<Building, BuildingResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(BuildingResource resource)
        {
            var building = _mapper.Map<BuildingResource, Building>(resource);
            await _unitOfWork.Buildings.UpdateAsync(resource.Id, building);

            return await _unitOfWork.SaveAsync();
        }
    }
}
