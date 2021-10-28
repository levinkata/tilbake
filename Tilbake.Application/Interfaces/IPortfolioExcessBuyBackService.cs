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
        void Add(PortfolioExcessBuyBackSaveResource resource);
        void Update(PortfolioExcessBuyBackResource resource);
        void Delete(Guid id);
    }
}