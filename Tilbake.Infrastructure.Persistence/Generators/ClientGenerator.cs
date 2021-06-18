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
    public class ClientGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        private TilbakeDbContext _context;

        public ClientGenerator()
        {
        }

        /// <summary>
        /// Template method to perform value generation for ClientNumber.
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

            var currentValue = _context.ClientNumberGenerators.Any() ?
                                    _context.ClientNumberGenerators
                                    .Max(p => p.ClientNumber) + 1 : 1;

            var invoiceTable = _context.ClientNumberGenerators
                                            .FirstOrDefault();

            if (invoiceTable == null)
            {
                ClientNumberGenerator invoiceNumberGenerator = new ClientNumberGenerator()
                {
                    ClientNumber = currentValue
                };
                _context.ClientNumberGenerators.Add(invoiceNumberGenerator);
            }
            else
                invoiceTable.ClientNumber = currentValue;

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

            var currentValue = _context.ClientNumberGenerators.Any() ?
                                    _context.ClientNumberGenerators
                                    .Max(p => p.ClientNumber) + 1 : 1;

            var invoiceTable = await _context.ClientNumberGenerators
                                            .FirstOrDefaultAsync(cancellationToken)
                                            .ConfigureAwait(false);

            if (invoiceTable == null)
            {
                ClientNumberGenerator invoiceNumberGenerator = new ClientNumberGenerator()
                {
                    ClientNumber = currentValue
                };
                await _context.ClientNumberGenerators.AddAsync(invoiceNumberGenerator, cancellationToken)
                                                     .ConfigureAwait(false);
            }
            else
                invoiceTable.ClientNumber = currentValue;

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return currentValue;
        }        
    }
}