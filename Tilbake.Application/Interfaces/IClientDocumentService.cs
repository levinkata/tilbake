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
        void Add(ClientDocumentSaveResource resource);
        void Update(ClientDocumentResource resource);
        void Delete(Guid id);
    }
}
