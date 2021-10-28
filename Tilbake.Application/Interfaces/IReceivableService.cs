using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IReceivableService
    {
        Task<IEnumerable<ReceivableResource>> GetAllAsync();
        Task<IEnumerable<ReceivableResource>> GetByInvoiceIdAsync(Guid invoiceId);
        Task<ReceivableResource> GetByIdAsync(Guid id);
        void Add(ReceivableSaveResource resource);
        void AddQuote(ReceivableSaveResource resource);
        void Update(ReceivableResource resource);
        void Delete(Guid id);
    }
}
