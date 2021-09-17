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

            await _unitOfWork.Houses.AddAsync(house);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Houses.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(HouseResource resource)
        {
            var house = _mapper.Map<HouseResource, House>(resource);
            await _unitOfWork.Houses.DeleteAsync(house);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<HouseResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Houses.GetAllAsync(
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
            var result = await _unitOfWork.Houses.GetFirstOrDefaultAsync(
                                            r => r.Id == id,
                                            r => r.HouseCondition,
                                            r => r.ResidenceType,
                                            r => r.RoofType,
                                            r => r.WallType);

            var resource = _mapper.Map<House, HouseResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(HouseResource resource)
        {
            var house = _mapper.Map<HouseResource, House>(resource);
            await _unitOfWork.Houses.UpdateAsync(resource.Id, house);

            return await _unitOfWork.SaveAsync();
        }
    }
}
