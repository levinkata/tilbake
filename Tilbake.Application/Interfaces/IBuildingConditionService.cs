using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IBuildingConditionService
    {
        Task<IEnumerable<BuildingConditionResource>> GetAllAsync();
        Task<BuildingConditionResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(BuildingConditionSaveResource resource);
        Task<int> UpdateAsync(BuildingConditionResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(BuildingConditionResource resource);
    }
}
