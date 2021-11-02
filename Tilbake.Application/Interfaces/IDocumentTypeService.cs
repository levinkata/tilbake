using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IDocumentTypeService
    {
        Task<IEnumerable<DocumentTypeResource>> GetAllAsync();
        Task<DocumentTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(DocumentTypeSaveResource resource);
        Task<int> UpdateAsync(DocumentTypeResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}