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
        void Add(IdDocumentTypeSaveResource resource);
        void Update(IdDocumentTypeResource resource);
        void Delete(Guid id);
    }
}
