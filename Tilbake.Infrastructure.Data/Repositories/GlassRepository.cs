using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class GlassRepository : IGlassRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public GlassRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Guid klientId, Glass glass)
        {
            if (glass == null)
            {
                throw new ArgumentNullException(nameof(glass));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await Task.Run(async () =>
                {
                    glass.ID = Guid.NewGuid();
                    await _context.Glasses.AddAsync((Glass)glass).ConfigureAwait(true);

                    if (klientId != null && klientId != Guid.Empty)
                    {
                        Risk risk = new Risk()
                        {
                            ID = Guid.NewGuid(),
                            GlassID = glass.ID
                        };
                        await _context.Risks.AddAsync((Risk)risk).ConfigureAwait(true);

                        KlientRisk klientRisk = new KlientRisk()
                        {
                            ID = Guid.NewGuid(),
                            KlientID = klientId,
                            RiskID = risk.ID
                        };
                        await _context.KlientRisks.AddAsync((KlientRisk)klientRisk).ConfigureAwait(true);
                    }

                }).ConfigureAwait(true);

                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            Glass glass = await _context.Glasses.FindAsync(id).ConfigureAwait(true);
            _context.Glasses.Remove((Glass)glass);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Glass>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Glasses
                                                .Include(m => m.RiskItem)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .OrderBy(n => n.RiskItem.Description).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Glass> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Glasses
                                                .Include(m => m.RiskItem)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Glass glass)
        {
            if (glass == null)
            {
                throw new ArgumentNullException(nameof(glass));
            };

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                _context.Glasses.Update((Glass)glass);

                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException e)
            {
                return e.HResult;
            }
        }
    }
}
