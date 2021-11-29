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