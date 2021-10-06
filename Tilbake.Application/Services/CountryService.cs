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
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CountrySaveResource resource)
        {
            var country = _mapper.Map<CountrySaveResource, Country>(resource);
            country.Id = Guid.NewGuid();

            await _unitOfWork.Countries.AddAsync(country);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Countries.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(CountryResource resource)
        {
            var country = _mapper.Map<CountryResource, Country>(resource);
            await _unitOfWork.Countries.DeleteAsync(country);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CountryResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Countries.GetAllAsync();
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(result);

            return resources;
        }

        public async Task<CountryResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Countries.GetByIdAsync(id);
            var resources = _mapper.Map<Country, CountryResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(CountryResource resource)
        {
            var country = _mapper.Map<CountryResource, Country>(resource);
            await _unitOfWork.Countries.UpdateAsync(resource.Id, country);

            return await _unitOfWork.SaveAsync();
        }
    }
}
