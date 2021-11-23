using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IPortfolioClientRepository : IRepository<PortfolioClient>
    {
        Task<IEnumerable<Client>> GetByPortfolioId(Guid portfolioId);
        Task<Client> GetByPortfolioIdAndIdNumber(Guid portfolioId, string idNumber);
        Task<Client> GetByPortfolioIdAndClientId(Guid portfolioId, Guid clientId);
    }
}