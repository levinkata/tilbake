using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class MotorModelRepository : Repository<MotorModel>, IMotorModelRepository
    {
        public MotorModelRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<MotorModel>> GetByMotorMakeIdAsync(Guid motorMakeId)
        {
            return await Task.Run(() => _context.MotorModels
                                                .Include(b => b.MotorMake)
                                                .Where(e => e.MotorMakeId == motorMakeId)
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking()).ConfigureAwait(true);
        }
    }
}