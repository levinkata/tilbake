using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IBankBranchService
    {
        Task<IEnumerable<BankBranchResource>> GetAllAsync();
        Task<IEnumerable<BankBranchResource>> GetByBankId(Guid bankId);
        Task<BankBranchResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(BankBranchSaveResource resource);
        Task<int> UpdateAsync(BankBranchResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(BankBranchResource resource);
    }
}