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
    public class CountryRepository : ICountryRepository
    {
        private readonly TilbakeDbContext _context;

        public CountryRepository(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Country> AddAsync(Country country)
        {
            await _context.Countries.AddAsync(country).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return country;
        }

        public async Task<IEnumerable<Country>> AddRangeAsync(IEnumerable<Country> countrys)
        {
            await _context.Countries.AddRangeAsync(countrys).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return countrys;
        }

        public async Task<Country> DeleteAsync(Guid id)
        {
            Country country = await _context.Countries
                                    .Where(e => e.Id == id)
                                    .FirstOrDefaultAsync().ConfigureAwait(true);            
            if (country == null)
            {
                return country;
            }

            await Task.Run(() => _context.Countries.Remove(country)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return country;
        }

        public async Task<Country> DeleteAsync(Country country)
        {
            if (country == null)
            {
                return country;
            }
            
            await Task.Run(() => _context.Countries.Remove(country)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return country;
        }

        public async Task<IEnumerable<Country>> DeleteRangeAsync(IEnumerable<Country> countrys)
        {
            if (countrys == null)
            {
                return countrys;
            }

            await Task.Run(() => _context.Countries.RemoveRange(countrys)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return countrys;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            IEnumerable<Country> countrys = _context.Countries.OrderBy(n => n.Name).AsNoTracking();
            return await Task.Run(() => countrys).ConfigureAwait(true);
        }

        public async Task<Country> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _context.Countries
                                                .Where(e => e.Id == id)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }

        public async Task<Country> UpdateAsync(Country country)
        {
            if (country == null)
            {
                return country;
            }
            
            await Task.Run(() => _context.Countries.Update(country)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return country;
        }
    }
}