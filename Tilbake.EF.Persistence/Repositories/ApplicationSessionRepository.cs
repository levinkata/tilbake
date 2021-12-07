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
    public class ApplicationSessionRepository : Repository<ApplicationSession>, IApplicationSessionRepository
    {
        public ApplicationSessionRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task DeleteByUserId(string userId)
        {
            var entityToDelete = await _context.ApplicationSessions
                                .Where(r => r.UserId == Guid.Parse(userId))
                                .AsNoTracking().ToListAsync();

            if (entityToDelete != null)
            {
                _context.ApplicationSessions.RemoveRange(entityToDelete);
            }
        }

        public async Task<IEnumerable<ApplicationSession>> GetByUserId(string userId)
        {
            return await _context.ApplicationSessions
                                .Where(r => r.UserId == Guid.Parse(userId))
                                .OrderBy(r => r.UserId).AsNoTracking().ToListAsync();
        }
    }
}