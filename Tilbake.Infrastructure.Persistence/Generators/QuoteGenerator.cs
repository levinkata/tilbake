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
    public class QuoteGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        private TilbakeDbContext _context;

        public QuoteGenerator()
        {
        }

        /// <summary>
        /// Template method to perform value generation for QuoteNumber.
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

            var currentValue = _context.QuoteNumberGenerators.Any() ?
                                    _context.QuoteNumberGenerators
                                    .Max(p => p.QuoteNumber) + 1 : 1;

            var invoiceTable = _context.QuoteNumberGenerators
                                            .FirstOrDefault();

            if (invoiceTable == null)
            {
                QuoteNumberGenerator invoiceNumberGenerator = new QuoteNumberGenerator()
                {
                    QuoteNumber = currentValue
                };
                _context.QuoteNumberGenerators.Add(invoiceNumberGenerator);
            }
            else
                invoiceTable.QuoteNumber = currentValue;

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

            var currentValue = _context.QuoteNumberGenerators.Any() ?
                                    _context.QuoteNumberGenerators
                                    .Max(p => p.QuoteNumber) + 1 : 1;

            var invoiceTable = await _context.QuoteNumberGenerators
                                            .FirstOrDefaultAsync(cancellationToken)
                                            .ConfigureAwait(false);

            if (invoiceTable == null)
            {
                QuoteNumberGenerator invoiceNumberGenerator = new QuoteNumberGenerator()
                {
                    QuoteNumber = currentValue
                };
                await _context.QuoteNumberGenerators.AddAsync(invoiceNumberGenerator, cancellationToken)
                                                     .ConfigureAwait(false);
            }
            else
                invoiceTable.QuoteNumber = currentValue;

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return currentValue;
        }        
    }
}