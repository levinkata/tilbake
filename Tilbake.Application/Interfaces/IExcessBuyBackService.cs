using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IExcessBuyBackService
    {
        Task<IEnumerable<ExcessBuyBackResource>> GetAllAsync();
        Task<ExcessBuyBackResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(ExcessBuyBackSaveResource resource);
        Task<int> UpdateAsync(ExcessBuyBackResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}