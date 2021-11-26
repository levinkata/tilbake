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
    public class RatingMotorDiscountRepository : Repository<RatingMotorDiscount>, IRatingMotorDiscountRepository
    {
        public RatingMotorDiscountRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<RatingMotorDiscount>> GetByInsurer(Guid insurerId)
        {
            return await _context.RatingMotorDiscounts
                                .Where(r => r.InsurerId == insurerId)
                                .OrderBy(p => p.ClaimFreeGroup)
                                .Include(r => r.Insurer).AsNoTracking().ToListAsync();
        }
    }
}
