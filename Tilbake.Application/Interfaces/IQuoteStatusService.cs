using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IQuoteStatusService
    {
        Task<IEnumerable<QuoteStatusResource>> GetAllAsync();
        Task<QuoteStatusResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(QuoteStatusSaveResource resource);
        Task<int> UpdateAsync(QuoteStatusResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}