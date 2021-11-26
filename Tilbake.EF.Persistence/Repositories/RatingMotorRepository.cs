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
    public class RatingMotorRepository : Repository<RatingMotor>, IRatingMotorRepository
    {
        public RatingMotorRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<RatingMotor>> GetByInsurerId(Guid insurerId)
        {
            return await _context.RatingMotors
                                .Where(r => r.InsurerId == insurerId)
                                .OrderBy(p => p.StartValue)
                                .Include(r => r.Insurer).AsNoTracking().ToListAsync();
        }
    }
}
