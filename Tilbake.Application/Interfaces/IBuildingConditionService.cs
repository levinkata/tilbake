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
        void Add(BuildingConditionSaveResource resource);
        void Update(BuildingConditionResource resource);
        void Delete(Guid id);
    }
}
