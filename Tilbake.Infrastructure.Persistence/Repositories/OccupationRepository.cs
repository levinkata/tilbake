using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IEnumerable<Occupation>> AddRangeAsync(IEnumerable<Occupation> occupations)
        {
            await _context.Occupations.AddRangeAsync(occupations).ConfigureAwait(true);
            //  await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
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
            //  var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier) // will give the user's userId
            //  ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

            await Task.Run(() => _context.Occupations.Remove(occupation)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            //  await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            return occupation;
        }

        public async Task<IEnumerable<Occupation>> DeleteRangeAsync(IEnumerable<Occupation> occupations)
        {
            if (occupations == null)
            {
                return occupations;
            }

            await Task.Run(() => _context.Occupations.RemoveRange(occupations)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return occupations;
        }

        public async Task<IEnumerable<Occupation>> GetAllAsync()
        {
            IEnumerable<Occupation> occupations = _context.Occupations.OrderBy(n => n.Name).AsNoTracking();
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
            
            // await Task.Run(() => _context.Occupations.Update(occupation)).ConfigureAwait(true);

            ///  New lines inserted to generate a lot more efficient and cleaner SQL of:
            /// Update Students Set Class = 12 where Id = 1;
            /// instead of:
            /// Update Students Set Age = 25, Class = 12, Name = 'Mukesh' where Id = 1;
            //  var oldOccupation = await _context.Occupations.FindAsync(occupation.Id);
            //  await Task.Run(() => _context.Entry(oldOccupation).CurrentValues.SetValues(occupation)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            //  await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return occupation;
        }
    }
}