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
        void Add(QuoteStatusSaveResource resource);
        void Update(QuoteStatusResource resource);
        void Delete(Guid id);
    }
}