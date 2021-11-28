using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IReceivableRepository : IRepository<Receivable>
    {
        Task<IEnumerable<Receivable>> GetByInvoiceId(Guid invoiceId);
    }
}
