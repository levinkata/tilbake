using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class CarrierRepository : ICarrierRepository
    {
        private readonly TilbakeDbContext _context;

        public CarrierRepository(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Carrier> AddAsync(Carrier carrier)
        {
            await _context.Carriers.AddAsync(carrier).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return carrier;
        }

        public async Task<IQueryable<Carrier>> AddRangeAsync(IQueryable<Carrier> carriers)
        {
            await _context.Carriers.AddRangeAsync(carriers).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return carriers;
        }

        public async Task<Carrier> DeleteAsync(Guid id)
        {
            Carrier carrier = await _context.Carriers
                                    .Where(e => e.Id == id)
                                    .FirstOrDefaultAsync().ConfigureAwait(true);            
            if (carrier == null)
            {
                return carrier;
            }

            await Task.Run(() => _context.Carriers.Remove(carrier)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return carrier;
        }

        public async Task<Carrier> DeleteAsync(Carrier carrier)
        {
            if (carrier == null)
            {
                return carrier;
            }
            
            await Task.Run(() => _context.Carriers.Remove(carrier)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return carrier;
        }

        public async Task<IQueryable<Carrier>> DeleteRangeAsync(IQueryable<Carrier> carriers)
        {
            if (carriers == null)
            {
                return carriers;
            }

            await Task.Run(() => _context.Carriers.RemoveRange(carriers)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return carriers;
        }

        public async Task<IQueryable<Carrier>> GetAllAsync()
        {
            IQueryable<Carrier> carriers = _context.Carriers.OrderBy(n => n.Name).AsNoTracking();
            return await Task.Run(() => carriers).ConfigureAwait(true);
        }

        public async Task<Carrier> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _context.Carriers
                                                .Where(e => e.Id == id)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }

        public async Task<Carrier> UpdateAsync(Carrier carrier)
        {
            if (carrier == null)
            {
                return carrier;
            }
            
            await Task.Run(() => _context.Carriers.Update(carrier)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return carrier;
        }
    }
}