using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<Portfolio>> GetAllAsync();
        Task<Portfolio> GetByIdAsync(Guid id);
        Task<int> AddAsync(Portfolio portfolio);
        Task<int> AddRangeAsync (IEnumerable<Portfolio> portfolios);
        Task<int> UpdateAsync(Portfolio portfolio);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(Portfolio portfolio);
        Task<int> DeleteRangeAsync(IEnumerable<Portfolio> portfolios);  
    }    
}