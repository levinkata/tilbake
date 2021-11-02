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
    public class HouseService : IHouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HouseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(HouseSaveResource resource)
        {
            var house = _mapper.Map<HouseSaveResource, House>(resource);
            house.Id = Guid.NewGuid();
            house.DateAdded = DateTime.Now;

            _unitOfWork.Houses.Add(house);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.Houses.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<HouseResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Houses.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.PhysicalAddress),
                                            r => r.HouseCondition,
                                            r => r.ResidenceType,
                                            r => r.RoofType,
                                            r => r.WallType);

            var resources = _mapper.Map<IEnumerable<House>, IEnumerable<HouseResource>>(result);
            return resources;
        }

        public async Task<HouseResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Houses.GetAsync(
                                            r => r.Id == id,
                                            null,
                                            r => r.HouseCondition,
                                            r => r.ResidenceType,
                                            r => r.RoofType,
                                            r => r.WallType);

            var resource = _mapper.Map<House, HouseResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(HouseResource resource)
        {
            var house = _mapper.Map<HouseResource, House>(resource);
            _unitOfWork.Houses.Update(resource.Id, house);

            return await _unitOfWork.SaveAsync();
        }
    }
}
