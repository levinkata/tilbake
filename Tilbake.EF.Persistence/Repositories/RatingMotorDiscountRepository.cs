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
