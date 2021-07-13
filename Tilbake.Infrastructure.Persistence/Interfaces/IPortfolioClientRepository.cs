using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IPortfolioClientRepository : IRepository<PortfolioClient>
    {
        Task<IEnumerable<Client>> GetByPortfolioId(Guid portfolioId);
        Task<Client> GetByClientId(Guid portfolioId, Guid clientId);
        Task<PortfolioClient> AddClientAsync(Guid portfolioId, Client client);
        Task<bool> ExistsAsync(Guid portfolioId, Guid clientId);
    }
}