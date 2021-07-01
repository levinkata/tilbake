using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IClientTypeRepository
    {
        Task<IQueryable<ClientType>> GetAllAsync();
        Task<ClientType> GetByIdAsync(Guid id);
        Task<ClientType> AddAsync(ClientType clientType);
        Task <IQueryable<ClientType>> AddRangeAsync (IQueryable<ClientType> clientTypes);
        Task<ClientType> UpdateAsync(ClientType clientType);
        Task<ClientType> DeleteAsync(Guid id);
        Task<ClientType> DeleteAsync(ClientType clientType);
        Task<IQueryable<ClientType>> DeleteRangeAsync(IQueryable<ClientType> clientTypes);  
    }    
}