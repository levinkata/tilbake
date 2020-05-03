using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IBankBranchRepository
    {
        Task<IEnumerable<BankBranch>> GetAllAsync(Guid bankId);
        Task<BankBranch> GetAsync(Guid id);
        Task<int> AddAsync(BankBranch bankBranch);
        Task<int> UpdateAsync(BankBranch bankBranch);
        Task<int> DeleteAsync(Guid id);
    }
}
