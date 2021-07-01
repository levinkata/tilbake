using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly TilbakeDbContext _context;

        public GenderRepository(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Gender> AddAsync(Gender gender)
        {
            await _context.Genders.AddAsync(gender).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return gender;
        }

        public async Task<IQueryable<Gender>> AddRangeAsync(IQueryable<Gender> genders)
        {
            await _context.Genders.AddRangeAsync(genders).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return genders;
        }

        public async Task<Gender> DeleteAsync(Guid id)
        {
            Gender gender = await _context.Genders
                                    .Where(e => e.Id == id)
                                    .FirstOrDefaultAsync().ConfigureAwait(true);            
            if (gender == null)
            {
                return gender;
            }

            await Task.Run(() => _context.Genders.Remove(gender)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return gender;
        }

        public async Task<Gender> DeleteAsync(Gender gender)
        {
            if (gender == null)
            {
                return gender;
            }
            
            await Task.Run(() => _context.Genders.Remove(gender)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return gender;
        }

        public async Task<IQueryable<Gender>> DeleteRangeAsync(IQueryable<Gender> genders)
        {
            if (genders == null)
            {
                return genders;
            }

            await Task.Run(() => _context.Genders.RemoveRange(genders)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return genders;
        }

        public async Task<IQueryable<Gender>> GetAllAsync()
        {
            IQueryable<Gender> genders = _context.Genders.OrderBy(n => n.Name).AsNoTracking();
            return await Task.Run(() => genders).ConfigureAwait(true);
        }

        public async Task<Gender> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _context.Genders
                                                .Where(e => e.Id == id)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }

        public async Task<Gender> UpdateAsync(Gender gender)
        {
            if (gender == null)
            {
                return gender;
            }
            
            await Task.Run(() => _context.Genders.Update(gender)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return gender;
        }
    }
}