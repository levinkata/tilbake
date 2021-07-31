using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceResource>> GetAllAsync();
        Task<InvoiceResource> GetByIdAsync(Guid id);
        Task<InvoiceResource> GetByPolicyIdAsync(Guid policyId);
        Task<InvoiceResource> GetByPortfolioClientIdAsync(Guid portfolioClientId);
        Task<int> AddAsync(InvoiceSaveResource resource);
        Task<int> UpdateAsync(InvoiceResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(InvoiceResource resource);
    }
}