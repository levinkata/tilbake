using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IReceivableDocumentService
    {
        Task<IEnumerable<ReceivableDocumentResource>> GetAllAsync();
        Task<IEnumerable<ReceivableDocumentResource>> GetReceivableIdAsync(Guid receivableId);
        Task<ReceivableDocumentResource> GetByIdAsync(Guid id);
        void Add(ReceivableDocumentSaveResource resource);
        void Update(ReceivableDocumentResource resource);
        void Delete(Guid id);
    }
}
