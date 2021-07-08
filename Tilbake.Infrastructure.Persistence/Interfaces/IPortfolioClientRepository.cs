using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IPortfolioClientRepository
    {
        Task<IEnumerable<PortfolioClient>> GetAllAsync();
        Task<PortfolioClient> GetByIdAsync(Guid id);
        Task<int> AddAsync(PortfolioClient portfolioClient);
        Task<int> DeleteAsync(Guid id);
    }    
}