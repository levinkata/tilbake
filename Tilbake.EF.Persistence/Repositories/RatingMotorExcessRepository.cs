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
