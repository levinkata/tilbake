using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryResource>> GetAllAsync();
        Task<CountryResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(CountrySaveResource resource);
        Task<int> UpdateAsync(CountryResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(CountryResource resource);
    }
}