using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IOccupationService
    {
        Task<IEnumerable<OccupationResource>> GetAllAsync();
        Task<OccupationResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(OccupationSaveResource resource);
        Task<int> UpdateAsync(OccupationResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}