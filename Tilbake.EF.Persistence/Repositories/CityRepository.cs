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
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<City>> GetByCountryId(Guid countryId)
        {
            return await _context.Cities
                                .Where(c => c.CountryId == countryId)
                                .Include(c => c.Country)
                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync();
        }
    }
}