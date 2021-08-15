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
            city.DateAdded = DateTime.Now;

            await _unitOfWork.Cities.AddAsync(city);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Cities.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(CityResource resource)
        {
            var city = _mapper.Map<CityResource, City>(resource);
            await _unitOfWork.Cities.DeleteAsync(city);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CityResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Cities.GetAllAsync(
                                                null,
                                                r => r.OrderBy(n => n.Name),
                                                r => r.Country);

            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<CityResource>> GetByCountryId(Guid countryId)
        {
            var result = await _unitOfWork.Cities.GetAllAsync(
                                            e => e.CountryId == countryId,
                                            e => e.OrderBy(r => r.Name),
                                            e => e.Country);

            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(result);
            return resources;
        }

        public async Task<CityResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Cities.GetByIdAsync(id);
            var resource = _mapper.Map<City, CityResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(CityResource resource)
        {
            var city = _mapper.Map<CityResource, City>(resource);
            city.DateModified = DateTime.Now;

            await _unitOfWork.Cities.UpdateAsync(resource.Id, city);
            return await _unitOfWork.SaveAsync();
        }
    }
}
