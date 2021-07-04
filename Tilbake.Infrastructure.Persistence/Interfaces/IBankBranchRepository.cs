using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IBankBranchRepository
    {
        Task<IEnumerable<BankBranch>> GetAllAsync();
        Task<BankBranch> GetByIdAsync(Guid id);
        Task<IEnumerable<BankBranch>> GetByBankId(Guid bankId);
        Task<BankBranch> AddAsync(BankBranch bankBranch);
        Task <IEnumerable<BankBranch>> AddRangeAsync (IEnumerable<BankBranch> bankBranches);        
        Task<BankBranch> UpdateAsync(BankBranch bankBranch);
        Task<BankBranch> DeleteAsync(Guid id);
        Task<BankBranch> DeleteAsync(BankBranch bankBranch);
        Task<IEnumerable<BankBranch>> DeleteRangeAsync(IEnumerable<BankBranch> bankBranches); 
    }    
}