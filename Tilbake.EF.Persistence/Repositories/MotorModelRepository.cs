using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Tilbake.EF.Persistence.Repositories
{
    public class MotorModelRepository : Repository<MotorModel>, IMotorModelRepository
    {
        public MotorModelRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<MotorModel>> GetByMotorMakeId(Guid motorMakeId)
        {
            return await _context.MotorModels
                                .Where(r => r.MotorMakeId == motorMakeId)
                                .OrderBy(r => r.Name).AsNoTracking().ToListAsync();
        }
    }
}