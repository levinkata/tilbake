using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IQuoteItemRepository : IRepository<QuoteItem>
    {
        Task<IEnumerable<QuoteItem>> GetByQuoteIdAsync(Guid quoteId);
    }
}