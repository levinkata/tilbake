using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ISalesTypeService
    {
        Task<IEnumerable<SalesTypeResource>> GetAllAsync();
        Task<SalesTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(SalesTypeSaveResource resource);
        Task<int> UpdateAsync(SalesTypeResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}