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
    public class HouseRepository : IHouseRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HouseRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Guid klientId, House house)
        {
            if (house == null)
            {
                throw new ArgumentNullException(nameof(house));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await Task.Run(async () =>
                {
                    house.ID = Guid.NewGuid();
                    await _context.Houses.AddAsync((House)house).ConfigureAwait(true);

                    if (klientId != null && klientId != Guid.Empty)
                    {
                        Risk risk = new Risk()
                        {
                            ID = Guid.NewGuid(),
                            HouseID = house.ID
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

            House house = await _context.Houses.FindAsync(id).ConfigureAwait(true);
            _context.Houses.Remove((House)house);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<House>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Houses
                                                .Include(m => m.ResidenceType)
                                                .Include(m => m.RoofType)
                                                .Include(m => m.WallType)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .OrderBy(n => n.Location).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<House> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Houses
                                                .Include(m => m.ResidenceType)
                                                .Include(m => m.RoofType)
                                                .Include(m => m.WallType)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(House house)
        {
            if (house == null)
            {
                throw new ArgumentNullException(nameof(house));
            };

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                _context.Houses.Update((House)house);

                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException e)
            {
                return e.HResult;
            }
        }
    }
}
