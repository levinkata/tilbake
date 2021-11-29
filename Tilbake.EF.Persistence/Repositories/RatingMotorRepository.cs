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
