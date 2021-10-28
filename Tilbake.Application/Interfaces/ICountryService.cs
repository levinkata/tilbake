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
        void Add(CountrySaveResource resource);
        void Update(CountryResource resource);
        void Delete(Guid id);
    }
}