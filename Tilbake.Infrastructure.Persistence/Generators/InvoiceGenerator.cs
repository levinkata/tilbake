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
                                        .AsNoTracking()
                                        .Max(p => p.InvoiceNumber) + 1 : 1;

            var invoiceTable = _context.InvoiceNumberGenerators
                                        .AsNoTracking()
                                        .OrderByDescending(e => e.InvoiceNumber)
                                        .FirstOrDefault();

            if (invoiceTable == null)
            {
                InvoiceNumberGenerator invoiceNumberGenerator = new()
                {
                    InvoiceNumber = currentValue
                };
                _context.InvoiceNumberGenerators.Add(invoiceNumberGenerator);
            }
            else
                invoiceTable.InvoiceNumber = currentValue;

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
                                        .AsNoTracking()
                                        .Max(p => p.InvoiceNumber) + 1 : 1;

            var invoiceTable = await _context.InvoiceNumberGenerators
                                            .AsNoTracking()
                                            .OrderByDescending(e => e.InvoiceNumber)
                                            .FirstOrDefaultAsync(cancellationToken);

            if (invoiceTable == null)
            {
                InvoiceNumberGenerator invoiceNumberGenerator = new()
                {
                    InvoiceNumber = currentValue
                };
                await _context.InvoiceNumberGenerators.AddAsync(invoiceNumberGenerator, cancellationToken);
            }
            else
                invoiceTable.InvoiceNumber = currentValue;

            return currentValue;
        }        
    }
}