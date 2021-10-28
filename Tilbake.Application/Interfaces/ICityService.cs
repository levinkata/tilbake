using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityResource>> GetAllAsync();
        Task<IEnumerable<CityResource>> GetByCountryId(Guid countryId);
        Task<CityResource> GetByIdAsync(Guid id);
        void Add(CitySaveResource resource);
        void Update(CityResource resource);
        void Delete(Guid id);
    }
}