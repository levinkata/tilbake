using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IClientTypeRepository
    {
        Task<IEnumerable<ClientType>> GetAllAsync();
        Task<ClientType> GetByIdAsync(Guid id);
        Task<ClientType> AddAsync(ClientType clientType);
        Task <IEnumerable<ClientType>> AddRangeAsync (IEnumerable<ClientType> clientTypes);
        Task<ClientType> UpdateAsync(ClientType clientType);
        Task<ClientType> DeleteAsync(Guid id);
        Task<ClientType> DeleteAsync(ClientType clientType);
        Task<IEnumerable<ClientType>> DeleteRangeAsync(IEnumerable<ClientType> clientTypes);  
    }    
}