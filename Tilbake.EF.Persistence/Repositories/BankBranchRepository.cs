using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

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