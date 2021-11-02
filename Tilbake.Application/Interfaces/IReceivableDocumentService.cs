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
        Task<int> AddAsync(ReceivableDocumentSaveResource resource);
        Task<int> UpdateAsync(ReceivableDocumentResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
