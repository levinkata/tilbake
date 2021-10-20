using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPortfolioExcessBuyBackService
    {
        Task<IEnumerable<PortfolioExcessBuyBackResource>> GetAllAsync();
        Task<IEnumerable<PortfolioExcessBuyBackResource>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<PortfolioExcessBuyBackResource> GetByIdAsync(Guid id);
        Task<PortfolioExcessBuyBackResource> AddAsync(PortfolioExcessBuyBackSaveResource resource);
        Task<PortfolioExcessBuyBackResource> UpdateAsync(PortfolioExcessBuyBackResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(PortfolioExcessBuyBackResource resource);
    }
}