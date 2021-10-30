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
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(CitySaveResource resource)
        {
            var city = _mapper.Map<CitySaveResource, City>(resource);
            city.Id = Guid.NewGuid();
            city.DateAdded = DateTime.Now;

            _unitOfWork.Cities.Add(city);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Cities.Delete(id);
            await _unitOfWork.SaveAsync();
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

        public async void Update(CityResource resource)
        {
            var city = _mapper.Map<CityResource, City>(resource);
            city.DateModified = DateTime.Now;

            _unitOfWork.Cities.Update(resource.Id, city);
            await _unitOfWork.SaveAsync();
        }
    }
}
