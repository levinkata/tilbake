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
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CitySaveResource resource)
        {
            var city = _mapper.Map<CitySaveResource, City>(resource);
            city.Id = Guid.NewGuid();

            await _unitOfWork.Cities.AddAsync(city);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Cities.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(CityResource resource)
        {
            var city = _mapper.Map<CityResource, City>(resource);
            await _unitOfWork.Cities.DeleteAsync(city);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<CityResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Cities.GetAllAsync());
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(result);

            return resources;
        }

        public async Task<CityResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Cities.GetByIdAsync(id);
            var resources = _mapper.Map<City, CityResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(CityResource resource)
        {
            var city = _mapper.Map<CityResource, City>(resource);
            await _unitOfWork.Cities.UpdateAsync(resource.Id, city);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
