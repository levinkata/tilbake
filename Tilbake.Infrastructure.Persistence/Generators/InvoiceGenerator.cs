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
    public class InvoiceGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        private TilbakeDbContext _context;

        public InvoiceGenerator()
        {
        }

        /// <summary>
        /// Template method to perform value generation for InvoiceNumber.
        /// </summary>
        /// <param name="entry">In this case Invoice</param>
        /// <returns>Current invoice number</returns>
        public override int Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            _context = (TilbakeDbContext)entry.Context;

            var currentValue = _context.InvoiceNumberGenerators.Any() ?
                                    _context.InvoiceNumberGenerators
                                    .Max(p => p.InvoiceNumber) + 1 : 1;

            var invoiceTable = _context.InvoiceNumberGenerators
                                            .FirstOrDefault();

            if (invoiceTable == null)
            {
                InvoiceNumberGenerator invoiceNumberGenerator = new InvoiceNumberGenerator()
                {
                    InvoiceNumber = currentValue
                };
                _context.InvoiceNumberGenerators.Add(invoiceNumberGenerator);
            }
            else
                invoiceTable.InvoiceNumber = currentValue;

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

            var currentValue = _context.InvoiceNumberGenerators.Any() ?
                                    _context.InvoiceNumberGenerators
                                    .Max(p => p.InvoiceNumber) + 1 : 1;

            var invoiceTable = await _context.InvoiceNumberGenerators
                                            .FirstOrDefaultAsync(cancellationToken)
                                            .ConfigureAwait(false);

            if (invoiceTable == null)
            {
                InvoiceNumberGenerator invoiceNumberGenerator = new InvoiceNumberGenerator()
                {
                    InvoiceNumber = currentValue
                };
                await _context.InvoiceNumberGenerators.AddAsync(invoiceNumberGenerator, cancellationToken)
                                                     .ConfigureAwait(false);
            }
            else
                invoiceTable.InvoiceNumber = currentValue;

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return currentValue;
        }        
    }
}