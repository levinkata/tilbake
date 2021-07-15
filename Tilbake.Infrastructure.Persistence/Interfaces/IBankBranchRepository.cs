using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IBankBranchRepository : IRepository<BankBranch>
    {
        Task<IEnumerable<BankBranch>> GetByBankIdAsync(Guid bankId);
    }    
}