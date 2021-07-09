using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<IEnumerable<Client>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<Client> GetByIdAsync(Guid id);
        Task<Client> GetByIdNumberAsync(string idNumber);
        Task<Client> AddAsync(Client client);
        Task<Client> AddToPortfolioAsync(Guid portfolioId, Client client);
        Task <IEnumerable<Client>> AddRangeAsync (IEnumerable<Client> clients);
        Task<Client> UpdateAsync(Client client);
        Task<Client> DeleteAsync(Guid id);
        Task<Client> DeleteAsync(Client client);
        Task<IEnumerable<Client>> DeleteRangeAsync(IEnumerable<Client> clients);  
    }    
}