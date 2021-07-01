using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        }

        public async Task<CountryResponse> AddAsync(Country country)
        {
            try
            {
                await _countryRepository.AddAsync(country).ConfigureAwait(true);
                return new CountryResponse(country);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CountryResponse($"An error occurred when saving the country: {ex.Message}");
            }
        }

        public async Task<CountryResponse> DeleteAsync(Guid id)
        {
            var existingCountry = await _countryRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingCountry == null)
                return new CountryResponse($"Country Id not found: {id}");

            try
            {
                await _countryRepository.DeleteAsync(existingCountry).ConfigureAwait(false);
                return new CountryResponse(existingCountry);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CountryResponse($"An error occurred when deleting the country: {ex.Message}");
            }
        }

        public async Task<CountryResponse> DeleteAsync(Country country)
        {
            if (country == null)
                return new CountryResponse($"Country not found: {country}");

            try
            {
                await _countryRepository.DeleteAsync(country).ConfigureAwait(false);
                return new CountryResponse(country);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CountryResponse($"An error occurred when deleting the country: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await Task.Run(() => _countryRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<CountryResponse> GetByIdAsync(Guid id)
        {
            var country = await _countryRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (country == null)
                return new CountryResponse($"Country Id not found: {id}");

            return new CountryResponse(country);
        }

        public async Task<CountryResponse> UpdateAsync(Guid id, Country country)
        {
            if (country == null)
                return new CountryResponse($"Country not found: {country}");

            var existingCountry = await _countryRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingCountry == null)
                return new CountryResponse($"Country Id not found: {id}");

            existingCountry.Name = country.Name;

            try
            {
                await _countryRepository.UpdateAsync(existingCountry).ConfigureAwait(false);
                return new CountryResponse(existingCountry);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CountryResponse($"An error occurred when updating the country: {ex.Message}");
            }
        }
    }
}