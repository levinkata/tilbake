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
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(CountrySaveResource resource)
        {
            var country = _mapper.Map<CountrySaveResource, Country>(resource);
            country.Id = Guid.NewGuid();

            _unitOfWork.Countries.Add(country);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Countries.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CountryResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Countries.FindAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name),
                                            r => r.Cities);

            var resources = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(result);

            return resources;
        }

        public async Task<CountryResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Countries.GetByIdAsync(id);
            var resource = _mapper.Map<Country, CountryResource>(result);
            return resource;
        }

        public async void Update(CountryResource resource)
        {
            var country = _mapper.Map<CountryResource, Country>(resource);
            _unitOfWork.Countries.Update(resource.Id, country);

            await _unitOfWork.SaveAsync();
        }
    }
}
