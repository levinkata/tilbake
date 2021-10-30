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

        public async void Add(BuildingSaveResource resource)
        {
            var building = _mapper.Map<BuildingSaveResource, Building>(resource);
            building.Id = Guid.NewGuid();
            building.DateAdded = DateTime.Now;

            _unitOfWork.Buildings.Add(building);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Buildings.Delete(id);
            await _unitOfWork.SaveAsync();
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

        public async void Update(BuildingResource resource)
        {
            var building = _mapper.Map<BuildingResource, Building>(resource);
            _unitOfWork.Buildings.Update(resource.Id, building);

            await _unitOfWork.SaveAsync();
        }
    }
}
