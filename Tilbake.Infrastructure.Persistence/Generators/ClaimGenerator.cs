using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.Infrastructure.Persistence.Generators
{
    public class ClaimGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        private TilbakeDbContext _context;

        public ClaimGenerator()
        {
        }

        /// <summary>
        /// Template method to perform value generation for ClaimNumber.
        /// </summary>
        /// <param name="entry">In this case Claim</param>
        /// <returns>Current claim number</returns>
        public override int Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            _context = (TilbakeDbContext)entry.Context;

            var currentValue = _context.ClaimNumberGenerators.Any() ?
                                    _context.ClaimNumberGenerators
                                    .AsNoTracking()
                                    .Max(p => p.ClaimNumber) + 1 : 1;

            var claimTable = _context.ClaimNumberGenerators
                                        .AsNoTracking()
                                        .OrderByDescending(e => e.ClaimNumber)
                                        .FirstOrDefault();

            if (claimTable == null)
            {
                ClaimNumberGenerator claimNumberGenerator = new()
                {
                    ClaimNumber = currentValue
                };
                _context.ClaimNumberGenerators.Add(claimNumberGenerator);
            }
            else
                claimTable.ClaimNumber = currentValue;

            return currentValue;
        }

        protected override async ValueTask<object> NextValueAsync(EntityEntry entry, CancellationToken cancellationToken = default)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            _context = (TilbakeDbContext)entry.Context;

            var currentValue = _context.ClaimNumberGenerators.Any() ?
                                    _context.ClaimNumberGenerators
                                    .AsNoTracking()
                                    .Max(p => p.ClaimNumber) + 1 : 1;

            var claimTable = await _context.ClaimNumberGenerators
                                            .AsNoTracking()
                                            .OrderByDescending(e => e.ClaimNumber)
                                            .FirstOrDefaultAsync(cancellationToken);

            if (claimTable == null)
            {
                ClaimNumberGenerator claimNumberGenerator = new()
                {
                    ClaimNumber = currentValue
                };
                await _context.ClaimNumberGenerators.AddAsync(claimNumberGenerator, cancellationToken);
            }
            else
                claimTable.ClaimNumber = currentValue;

            return currentValue;
        }        
    }
}