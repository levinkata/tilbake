using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IPortfolioExcessBuyBackRepository : IRepository<PortfolioExcessBuyBack>
    {
        Task<IEnumerable<PortfolioExcessBuyBack>> GetByPortfolioId(Guid portfolioId);
    }
}
