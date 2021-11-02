using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IBankService
    {
        Task<IEnumerable<BankResource>> GetAllAsync();
        Task<BankResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(BankSaveResource resource);
        Task<int> UpdateAsync(BankResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}