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

            await _unitOfWork.Houses.AddAsync(house);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Houses.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(HouseResource resource)
        {
            var house = _mapper.Map<HouseResource, House>(resource);
            await _unitOfWork.Houses.DeleteAsync(house);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<HouseResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Houses.GetAllAsync());
            result = result.OrderBy(n => n.PhysicalAddress);

            var resources = _mapper.Map<IEnumerable<House>, IEnumerable<HouseResource>>(result);

            return resources;
        }

        public async Task<HouseResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Houses.GetByIdAsync(id);
            var resources = _mapper.Map<House, HouseResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(HouseResource resource)
        {
            var house = _mapper.Map<HouseResource, House>(resource);
            await _unitOfWork.Houses.UpdateAsync(resource.Id, house);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
