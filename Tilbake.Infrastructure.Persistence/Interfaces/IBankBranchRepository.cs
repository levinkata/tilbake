using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IBankBranchRepository
    {
        Task<IQueryable<BankBranch>> GetAllAsync();
        Task<BankBranch> GetByIdAsync(Guid id);
        Task<IQueryable<BankBranch>> GetByBankId(Guid bankId);
        Task<BankBranch> AddAsync(BankBranch bankBranch);
        Task <IQueryable<BankBranch>> AddRangeAsync (IQueryable<BankBranch> bankBranches);        
        Task<BankBranch> UpdateAsync(BankBranch bankBranch);
        Task<BankBranch> DeleteAsync(Guid id);
        Task<BankBranch> DeleteAsync(BankBranch bankBranch);
        Task<IQueryable<BankBranch>> DeleteRangeAsync(IQueryable<BankBranch> bankBranches); 
    }    
}