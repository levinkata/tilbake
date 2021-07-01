using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IClientRepository
    {
        Task<IQueryable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(Guid id);
        Task<Client> AddAsync(Client client);
        Task <IQueryable<Client>> AddRangeAsync (IQueryable<Client> clients);
        Task<Client> UpdateAsync(Client client);
        Task<Client> DeleteAsync(Guid id);
        Task<Client> DeleteAsync(Client client);
        Task<IQueryable<Client>> DeleteRangeAsync(IQueryable<Client> clients);  
    }    
}