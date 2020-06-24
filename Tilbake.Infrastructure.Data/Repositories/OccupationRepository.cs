using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public OccupationRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Occupation occupation)
        {
            if (occupation == null)
            {
                throw new ArgumentNullException(nameof(occupation));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                occupation.Id = Guid.NewGuid();
                await context.Occupations.AddAsync((Occupation)occupation).ConfigureAwait(true);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            Occupation occupation = await context.Occupations.FindAsync(id).ConfigureAwait(true);
            context.Occupations.Remove((Occupation)occupation);
            return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Occupation>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Occupations
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Occupation> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Occupations
                                                .FirstOrDefaultAsync(e => e.Id == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Occupation occupation)
        {
            if (occupation == null)
            {
                throw new ArgumentNullException(nameof(occupation));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                context.Occupations.Update((Occupation)occupation);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
