using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceResource>> GetAllAsync();
        Task<IEnumerable<InvoiceResource>> GetByPolicyIdAsync(Guid policyId);
        Task<IEnumerable<InvoiceResource>> GetByPortfolioClientIdAsync(Guid portfolioClientId);
        Task<InvoiceResource> GetByIdAsync(Guid id);
        void Add(InvoiceSaveResource resource);
        void Update(InvoiceResource resource);
        void Delete(Guid id);
    }
}