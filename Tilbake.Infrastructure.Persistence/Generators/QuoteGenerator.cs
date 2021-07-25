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
        /// <param name="entry">In this case Quote</param>
        /// <returns>Current quote number</returns>
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

            var quoteTable = _context.QuoteNumberGenerators
                                        .OrderByDescending(e => e.QuoteNumber)
                                        .FirstOrDefault();

            if (quoteTable == null)
            {
                QuoteNumberGenerator quoteNumberGenerator = new QuoteNumberGenerator()
                {
                    QuoteNumber = currentValue
                };
                _context.QuoteNumberGenerators.Add(quoteNumberGenerator);
            }
            else
                quoteTable.QuoteNumber = currentValue;

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

            var quoteTable = await _context.QuoteNumberGenerators
                                            .OrderByDescending(e => e.QuoteNumber)
                                            .FirstOrDefaultAsync(cancellationToken)
                                            .ConfigureAwait(false);

            if (quoteTable == null)
            {
                QuoteNumberGenerator quoteNumberGenerator = new QuoteNumberGenerator()
                {
                    QuoteNumber = currentValue
                };
                await _context.QuoteNumberGenerators.AddAsync(quoteNumberGenerator, cancellationToken)
                                                     .ConfigureAwait(false);
            }
            else
                quoteTable.QuoteNumber = currentValue;

            return currentValue;
        }
    }
}