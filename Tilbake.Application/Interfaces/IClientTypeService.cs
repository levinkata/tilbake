using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface IClientTypeService
    {
        Task<IEnumerable<ClientType>> GetAllAsync();
        Task<ClientTypeResponse> GetByIdAsync(Guid id);
        Task<ClientTypeResponse> AddAsync(ClientType clientType);
        Task<ClientTypeResponse> UpdateAsync(Guid id, ClientType clientType);
        Task<ClientTypeResponse> DeleteAsync(Guid id);
        Task<ClientTypeResponse> DeleteAsync(ClientType clientType);
    }
}