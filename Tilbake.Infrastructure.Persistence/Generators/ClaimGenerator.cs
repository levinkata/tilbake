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
        /// <param name="entry">In this case FundEmployee</param>
        /// <returns>Current invoice number</returns>
        public override int Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            _context = (TilbakeDbContext)entry.Context;

            var currentValue = _context.ClaimNumberGenerators.Any() ?
                                    _context.ClaimNumberGenerators
                                    .Max(p => p.ClaimNumber) + 1 : 1;

            var invoiceTable = _context.ClaimNumberGenerators
                                            .FirstOrDefault();

            if (invoiceTable == null)
            {
                ClaimNumberGenerator invoiceNumberGenerator = new ClaimNumberGenerator()
                {
                    ClaimNumber = currentValue
                };
                _context.ClaimNumberGenerators.Add(invoiceNumberGenerator);
            }
            else
                invoiceTable.ClaimNumber = currentValue;

            _context.SaveChangesAsync();

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
                                    .Max(p => p.ClaimNumber) + 1 : 1;

            var invoiceTable = await _context.ClaimNumberGenerators
                                            .FirstOrDefaultAsync(cancellationToken)
                                            .ConfigureAwait(false);

            if (invoiceTable == null)
            {
                ClaimNumberGenerator invoiceNumberGenerator = new ClaimNumberGenerator()
                {
                    ClaimNumber = currentValue
                };
                await _context.ClaimNumberGenerators.AddAsync(invoiceNumberGenerator, cancellationToken)
                                                     .ConfigureAwait(false);
            }
            else
                invoiceTable.ClaimNumber = currentValue;

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return currentValue;
        }        
    }
}