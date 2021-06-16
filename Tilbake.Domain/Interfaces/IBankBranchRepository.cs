using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IBankBranchRepository : IRepository<BankBranch>
    {
        Task<IEnumerable<BankBranch>> GetByBankId(Guid bankId);
    }    
}