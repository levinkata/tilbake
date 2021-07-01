using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<CountryResponse> GetByIdAsync(Guid id);
        Task<CountryResponse> AddAsync(Country country);
        Task<CountryResponse> UpdateAsync(Guid id, Country country);
        Task<CountryResponse> DeleteAsync(Guid id);
        Task<CountryResponse> DeleteAsync(Country country);
    }
}