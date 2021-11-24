using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace Tilbake.EF.Persistence.Repositories
{
    public class InsurerBranchRepository : Repository<InsurerBranch>, IInsurerBranchRepository
    {
        public InsurerBranchRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<InsurerBranch>> GetByInsurerId(Guid insurerId)
        {
            return await _context.InsurerBranches
                                .Where(c => c.InsurerId == insurerId)
                                .Include(c => c.Insurer)
                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync();
        }

        public async Task<InsurerBranch> GetByName(string name)
        {
            return await _context.InsurerBranches
                                .Where(c => c.Name == name).FirstOrDefaultAsync();
        }
    }
}