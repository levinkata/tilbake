using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class BankBranchRepository : Repository<BankBranch>, IBankBranchRepository
    {
        public BankBranchRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<BankBranch>> GetByBankId(Guid bankId)
        {
            return await Task.Run(() => _context.BankBranches
                                                .Include(b => b.Bank)
                                                .Where(e => e.BankId == bankId)
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking()).ConfigureAwait(true);
        }
    }
}