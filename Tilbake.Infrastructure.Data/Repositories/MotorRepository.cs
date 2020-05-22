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
    public class MotorRepository : IMotorRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MotorRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Guid klientId, Motor motor)
        {
            if (motor == null)
            {
                throw new ArgumentNullException(nameof(motor));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await Task.Run(async () =>
                {
                    motor.ID = Guid.NewGuid();
                    await _context.Motors.AddAsync((Motor)motor).ConfigureAwait(true);

                    if (klientId != null && klientId != Guid.Empty)
                    {
                        Risk risk = new Risk()
                        {
                            ID = Guid.NewGuid(),
                            MotorID = motor.ID
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

        public async Task<bool> ChassissNumberExists(Guid id, string chassissNumber)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Motors
                                                .Any(e => e.ID != id && e.ChassisNumber == chassissNumber))
                                                .ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            Motor motor = await _context.Motors.FindAsync(id).ConfigureAwait(true);
            _context.Motors.Remove((Motor)motor);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<bool> EngineNumberExists(Guid id, string engineNumber)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Motors
                                                .Any(e => e.ID != id && e.EngineNumber == engineNumber))
                                                .ConfigureAwait(true);
        }

        public async Task<IEnumerable<Motor>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Motors
                                                .Include(m => m.BodyType)
                                                .Include(m => m.MotorMake)
                                                    .ThenInclude(m => m.MotorModels)
                                                .Include(m => m.DriverType)
                                                .Include(m => m.MotorUse)
                                                .Include(m => m.MotorImprovements)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .OrderBy(n => n.RegNumber).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Motor> GetByChassissNumberAsync(string chassissNumber)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Motors
                                                .Include(m => m.BodyType)
                                                .Include(m => m.MotorMake)
                                                    .ThenInclude(m => m.MotorModels)
                                                .Include(m => m.DriverType)
                                                .Include(m => m.MotorUse)
                                                .Include(m => m.MotorImprovements)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .SingleOrDefaultAsync(e => e.ChassisNumber == chassissNumber)).ConfigureAwait(true);
        }

        public async Task<Motor> GetByEngineNumberAsync(string engineNumber)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Motors
                                                .Include(m => m.BodyType)
                                                .Include(m => m.MotorMake)
                                                    .ThenInclude(m => m.MotorModels)
                                                .Include(m => m.DriverType)
                                                .Include(m => m.MotorUse)
                                                .Include(m => m.MotorImprovements)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .SingleOrDefaultAsync(e => e.EngineNumber == engineNumber)).ConfigureAwait(true);
        }

        public async Task<Motor> GetByRegNumberAsync(string regNumber)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Motors
                                                .Include(m => m.BodyType)
                                                .Include(m => m.MotorMake)
                                                    .ThenInclude(m => m.MotorModels)
                                                .Include(m => m.DriverType)
                                                .Include(m => m.MotorUse)
                                                .Include(m => m.MotorImprovements)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .SingleOrDefaultAsync(e => e.RegNumber == regNumber)).ConfigureAwait(true);
        }

        public async Task<Motor> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Motors
                                                .Include(m => m.BodyType)
                                                .Include(m => m.MotorMake)
                                                    .ThenInclude(m => m.MotorModels)
                                                .Include(m => m.DriverType)
                                                .Include(m => m.MotorUse)
                                                .Include(m => m.MotorImprovements)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<bool> RegNumberExists(Guid id, string regNumber)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Motors
                                                .Any(e => e.ID != id && e.RegNumber == regNumber))
                                                .ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Motor motor)
        {
            if (motor == null)
            {
                throw new ArgumentNullException(nameof(motor));
            };

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                _context.Motors.Update((Motor)motor);

                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException e)
            {
                return e.HResult;
            }
        }

        public async Task<IEnumerable<Motor>> GetByKlientAsync(Guid klientId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Motors
                                                .Include(m => m.BodyType)
                                                .Include(m => m.MotorMake)
                                                    .ThenInclude(m => m.MotorModels)
                                                .Include(m => m.DriverType)
                                                .Include(m => m.MotorUse)
                                                .Include(m => m.MotorImprovements)
                                                .Include(m => m.Risks)
                                                    .ThenInclude(k => k.KlientRisks)
                                                .Where(k => k.Risks.Any(r => r.KlientRisks.Any(k => k.KlientID == klientId)))
                                                .OrderBy(n => n.RegNumber).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }
    }
}
