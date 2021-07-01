using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly TilbakeDbContext _context;

        public OccupationRepository(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Occupation> AddAsync(Occupation occupation)
        {
            await _context.Occupations.AddAsync(occupation).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return occupation;
        }

        public async Task<IQueryable<Occupation>> AddRangeAsync(IQueryable<Occupation> occupations)
        {
            await _context.Occupations.AddRangeAsync(occupations).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return occupations;
        }

        public async Task<Occupation> DeleteAsync(Guid id)
        {
            Occupation occupation = await _context.Occupations
                                    .Where(e => e.Id == id)
                                    .FirstOrDefaultAsync().ConfigureAwait(true);            
            if (occupation == null)
            {
                return occupation;
            }

            await Task.Run(() => _context.Occupations.Remove(occupation)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return occupation;
        }

        public async Task<Occupation> DeleteAsync(Occupation occupation)
        {
            if (occupation == null)
            {
                return occupation;
            }
            
            await Task.Run(() => _context.Occupations.Remove(occupation)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return occupation;
        }

        public async Task<IQueryable<Occupation>> DeleteRangeAsync(IQueryable<Occupation> occupations)
        {
            if (occupations == null)
            {
                return occupations;
            }

            await Task.Run(() => _context.Occupations.RemoveRange(occupations)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return occupations;
        }

        public async Task<IQueryable<Occupation>> GetAllAsync()
        {
            IQueryable<Occupation> occupations = _context.Occupations.OrderBy(n => n.Name).AsNoTracking();
            return await Task.Run(() => occupations).ConfigureAwait(true);
        }

        public async Task<Occupation> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _context.Occupations
                                                .Where(e => e.Id == id)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }

        public async Task<Occupation> UpdateAsync(Occupation occupation)
        {
            if (occupation == null)
            {
                return occupation;
            }
            
            await Task.Run(() => _context.Occupations.Update(occupation)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return occupation;
        }
    }
}