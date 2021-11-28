using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RatingMotorPremiumRepository : Repository<RatingMotorPremium>, IRatingMotorPremiumRepository
    {
        public RatingMotorPremiumRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<RatingMotorPremium>> GetByInsurerId(Guid insurerId)
        {
            return await _context.RatingMotorPremiums
                                    .Where(r => r.InsurerId == insurerId)
                                    .OrderBy(p => p.MinimumMonthly)
                                    .Include(r => r.Insurer).AsNoTracking().ToListAsync();
        }
    }
}
