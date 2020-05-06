using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<Portfolio>> GetAllAsync();
        Task<Portfolio> GetAsync(Guid id);
        Task<int> AddAsync(Portfolio portfolio);
        Task<int> UpdateAsync(Portfolio portfolio);
        Task<int> DeleteAsync(Guid id);
    }
}
