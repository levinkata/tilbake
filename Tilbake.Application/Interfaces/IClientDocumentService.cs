using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IClientDocumentService
    {
        Task<IEnumerable<ClientDocumentResource>> GetAllAsync();
        Task<IEnumerable<ClientDocumentResource>> GetByClientIdAsync(Guid clientId);
        Task<ClientDocumentResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(ClientDocumentSaveResource resource);
        Task<int> UpdateAsync(ClientDocumentResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
