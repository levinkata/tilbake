using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetByIdNumberAsync(string idNumber);
        Task<IEnumerable<Client>> GetByPortfolioId(Guid portfolioId);
        Task<Client> GetByClientId(Guid portfolioId, Guid clientId);
    }
}