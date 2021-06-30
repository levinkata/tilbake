using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface IBankBranchService
    {
        Task<IEnumerable<BankBranch>> GetAllAsync();
        Task<IEnumerable<BankBranch>> GetByBankId(Guid bankId);
        Task<BankBranchResponse> GetByIdAsync(Guid id);
        Task<BankBranchResponse> AddAsync(BankBranch bankBranch);
        Task<BankBranchResponse> UpdateAsync(Guid id, BankBranch bankBranch);
        Task<BankBranchResponse> DeleteAsync(Guid id);
        Task<BankBranchResponse> DeleteAsync(BankBranch bankBranch);
    }
}