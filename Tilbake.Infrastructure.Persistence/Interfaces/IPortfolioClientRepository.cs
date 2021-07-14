using System;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IPortfolioClientRepository : IRepository<PortfolioClient>
    {
        Task<Guid> GetPortfolioClientId(Guid portfolioId, Guid clientId);
        Task<PortfolioClient> AddClientAsync(Guid portfolioId, Client client);
        Task<bool> ExistsAsync(Guid portfolioId, Guid clientId);
    }
}