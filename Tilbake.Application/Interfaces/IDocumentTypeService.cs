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
        void Add(DocumentTypeSaveResource resource);
        void Update(DocumentTypeResource resource);
        void Delete(Guid id);
    }
}