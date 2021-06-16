using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class BankBranchRepository : Repository<BankBranch>, IBankBranchRepository
    {
        public BankBranchRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<BankBranch>> GetByBankId(Guid bankId)
        {
            return await Task.Run(() => TilbakeDbContext.BankBranches
                                                        .Include(b => b.Bank)
                                                        .Where(b => b.BankId == bankId)
                                                        .OrderBy(n => n.Name)
                                                        .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public TilbakeDbContext TilbakeDbContext
        {
            get { return _context as TilbakeDbContext; }
        }        
    }
}