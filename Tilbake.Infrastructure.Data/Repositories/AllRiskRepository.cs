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
    public class AllRiskRepository : IAllRiskRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public AllRiskRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Guid klientId, AllRisk allRisk)
        {
            if (allRisk == null)
            {
                throw new ArgumentNullException(nameof(allRisk));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await Task.Run(async () =>
                {
                    allRisk.ID = Guid.NewGuid();
                    await _context.AllRisks.AddAsync((AllRisk)allRisk).ConfigureAwait(true);

                    if (klientId != null && klientId != Guid.Empty)
                    {
                        Risk risk = new Risk()
                        {
                            ID = Guid.NewGuid(),
                            AllRiskID = allRisk.ID
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

            AllRisk allRisk = await _context.AllRisks.FindAsync(id).ConfigureAwait(true);
            _context.AllRisks.Remove((AllRisk)allRisk);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<AllRisk>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.AllRisks
                                                .Include(m => m.RiskItem)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .OrderBy(n => n.RiskItem.Description).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<AllRisk> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.AllRisks
                                                .Include(m => m.RiskItem)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(AllRisk allRisk)
        {
            if (allRisk == null)
            {
                throw new ArgumentNullException(nameof(allRisk));
            };

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                _context.AllRisks.Update((AllRisk)allRisk);

                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException e)
            {
                return e.HResult;
            }
        }
    }
}
