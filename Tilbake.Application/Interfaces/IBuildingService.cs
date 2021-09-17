using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IBuildingService
    {
        Task<IEnumerable<BuildingResource>> GetAllAsync();
        Task<BuildingResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(BuildingSaveResource resource);
        Task<int> UpdateAsync(BuildingResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(BuildingResource resource);
    }
}
