using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ITravelService
    {
        Task<IEnumerable<TravelResource>> GetAllAsync();
        Task<TravelResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(TravelSaveResource resource);
        Task<int> UpdateAsync(TravelResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(TravelResource resource);
    }
}