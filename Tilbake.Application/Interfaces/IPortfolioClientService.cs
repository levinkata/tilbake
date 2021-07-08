using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPortfolioClientService
    {
        Task<IEnumerable<PortfolioClientResource>> GetAllAsync();
        Task<PortfolioClientResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PortfolioClientSaveResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}