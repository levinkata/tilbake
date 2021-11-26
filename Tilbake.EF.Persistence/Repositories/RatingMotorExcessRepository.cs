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
    public class RatingMotorExcessRepository : Repository<RatingMotorExcess>, IRatingMotorExcessRepository
    {
        public RatingMotorExcessRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<RatingMotorExcess>> GetByInsurerId(Guid insurerId)
        {
            return await _context.RatingMotorExcesses
                                .Where(r => r.InsurerId == insurerId)
                                .OrderBy(r => r.StartValue)
                                .Include(r => r.Insurer).AsNoTracking().ToListAsync();
        }
    }
}
