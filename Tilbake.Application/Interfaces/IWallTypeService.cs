using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IWallTypeService
    {
        Task<IEnumerable<WallTypeResource>> GetAllAsync();
        Task<WallTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(WallTypeSaveResource resource);
        Task<int> UpdateAsync(WallTypeResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(WallTypeResource resource);
    }
}
