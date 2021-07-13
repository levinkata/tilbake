using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityResource>> GetAllAsync();
        Task<CityResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(CitySaveResource resource);
        Task<int> UpdateAsync(CityResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(CityResource resource);
    }
}