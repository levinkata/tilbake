using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IBankBranchRepository : IRepository<BankBranch>
    {
        Task<IEnumerable<BankBranch>> GetByBankId(Guid bankId);
    }    
}