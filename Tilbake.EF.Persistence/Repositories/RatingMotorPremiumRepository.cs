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
    public class RatingMotorPremiumRepository : Repository<RatingMotorPremium>, IRatingMotorPremiumRepository
    {
        public RatingMotorPremiumRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<RatingMotorPremium>> GetByInsurerId(Guid insurerId)
        {
            return await _context.RatingMotorPremia
                                    .Where(r => r.InsurerId == insurerId)
                                    .OrderBy(p => p.MinimumMonthly)
                                    .Include(r => r.Insurer).AsNoTracking().ToListAsync();
        }
    }
}
