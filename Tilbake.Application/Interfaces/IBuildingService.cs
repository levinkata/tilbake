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
        void Add(BuildingSaveResource resource);
        void Update(BuildingResource resource);
        void Delete(Guid id);
    }
}
