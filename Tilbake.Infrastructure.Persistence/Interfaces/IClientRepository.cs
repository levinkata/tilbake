using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(Guid id);
        Task<Client> AddAsync(Client client);
        Task <IEnumerable<Client>> AddRangeAsync (IEnumerable<Client> clients);
        Task<Client> UpdateAsync(Client client);
        Task<Client> DeleteAsync(Guid id);
        Task<Client> DeleteAsync(Client client);
        Task<IEnumerable<Client>> DeleteRangeAsync(IEnumerable<Client> clients);  
    }    
}