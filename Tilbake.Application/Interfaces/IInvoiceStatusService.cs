using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IInvoiceStatusService
    {
        Task<IEnumerable<InvoiceStatusResource>> GetAllAsync();
        Task<InvoiceStatusResource> GetByIdAsync(Guid id);
        void Add(InvoiceStatusSaveResource resource);
        void Update(InvoiceStatusResource resource);
        void Delete(Guid id);
    }
}