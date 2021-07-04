using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class MaritalStatusRepository : IMaritalStatusRepository
    {
        private readonly TilbakeDbContext _context;

        public MaritalStatusRepository(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<MaritalStatus> AddAsync(MaritalStatus maritalStatus)
        {
            await _context.MaritalStatuses.AddAsync(maritalStatus).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return maritalStatus;
        }

        public async Task<IEnumerable<MaritalStatus>> AddRangeAsync(IEnumerable<MaritalStatus> maritalStatuses)
        {
            await _context.MaritalStatuses.AddRangeAsync(maritalStatuses).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return maritalStatuses;
        }

        public async Task<MaritalStatus> DeleteAsync(Guid id)
        {
            MaritalStatus maritalStatus = await _context.MaritalStatuses
                                    .Where(e => e.Id == id)
                                    .FirstOrDefaultAsync().ConfigureAwait(true);            
            if (maritalStatus == null)
            {
                return maritalStatus;
            }

            await Task.Run(() => _context.MaritalStatuses.Remove(maritalStatus)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return maritalStatus;
        }

        public async Task<MaritalStatus> DeleteAsync(MaritalStatus maritalStatus)
        {
            if (maritalStatus == null)
            {
                return maritalStatus;
            }
            
            await Task.Run(() => _context.MaritalStatuses.Remove(maritalStatus)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return maritalStatus;
        }

        public async Task<IEnumerable<MaritalStatus>> DeleteRangeAsync(IEnumerable<MaritalStatus> maritalStatuses)
        {
            if (maritalStatuses == null)
            {
                return maritalStatuses;
            }

            await Task.Run(() => _context.MaritalStatuses.RemoveRange(maritalStatuses)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return maritalStatuses;
        }

        public async Task<IEnumerable<MaritalStatus>> GetAllAsync()
        {
            IEnumerable<MaritalStatus> maritalStatuses = _context.MaritalStatuses.OrderBy(n => n.Name).AsNoTracking();
            return await Task.Run(() => maritalStatuses).ConfigureAwait(true);
        }

        public async Task<MaritalStatus> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _context.MaritalStatuses
                                                .Where(e => e.Id == id)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }

        public async Task<MaritalStatus> UpdateAsync(MaritalStatus maritalStatus)
        {
            if (maritalStatus == null)
            {
                return maritalStatus;
            }
            
            await Task.Run(() => _context.MaritalStatuses.Update(maritalStatus)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return maritalStatus;
        }
    }
}