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
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<City>> GetByCountryId(Guid countryId)
        {
            return await Task.Run(() => _context.Cities
                                                .Include(b => b.Country)
                                                .Where(e => e.CountryId == countryId)
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking()).ConfigureAwait(true);
        }
    }
}