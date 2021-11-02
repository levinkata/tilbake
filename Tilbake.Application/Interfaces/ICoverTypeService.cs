using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ICoverTypeService
    {
        Task<IEnumerable<CoverTypeResource>> GetAllAsync();
        Task<CoverTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(CoverTypeSaveResource resource);
        Task<int> UpdateAsync(CoverTypeResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}