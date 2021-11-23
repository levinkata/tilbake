using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tilbake.EF.Persistence.Repositories
{
    public class BankBranchRepository : Repository<BankBranch>, IBankBranchRepository
    {

        public BankBranchRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<BankBranch>> GetByBankId(Guid bankId)
        {
            return await _context.BankBranches
                                .Where(c => c.BankId == bankId)
                                .Include(c => c.Bank)
                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync();
        }
    }
}