using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IRoofTypeService
    {
        Task<IEnumerable<RoofTypeResource>> GetAllAsync();
        Task<RoofTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(RoofTypeSaveResource resource);
        Task<int> UpdateAsync(RoofTypeResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
