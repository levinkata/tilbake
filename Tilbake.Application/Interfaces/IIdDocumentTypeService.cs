using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IIdDocumentTypeService
    {
        Task<IEnumerable<IdDocumentTypeResource>> GetAllAsync();
        Task<IdDocumentTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(IdDocumentTypeSaveResource resource);
        Task<int> UpdateAsync(IdDocumentTypeResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
