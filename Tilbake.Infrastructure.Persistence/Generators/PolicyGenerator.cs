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
    public class PolicyGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        private TilbakeDbContext _context;

        public PolicyGenerator()
        {
        }

        /// <summary>
        /// Template method to perform value generation for PolicyNumber.
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

            var currentValue = _context.PolicyNumberGenerators.Any() ?
                                    _context.PolicyNumberGenerators
                                    .Max(p => p.PolicyNumber) + 1 : 1;

            var invoiceTable = _context.PolicyNumberGenerators
                                            .FirstOrDefault();

            if (invoiceTable == null)
            {
                PolicyNumberGenerator invoiceNumberGenerator = new PolicyNumberGenerator()
                {
                    PolicyNumber = currentValue
                };
                _context.PolicyNumberGenerators.Add(invoiceNumberGenerator);
            }
            else
                invoiceTable.PolicyNumber = currentValue;

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

            var currentValue = _context.PolicyNumberGenerators.Any() ?
                                    _context.PolicyNumberGenerators
                                    .Max(p => p.PolicyNumber) + 1 : 1;

            var invoiceTable = await _context.PolicyNumberGenerators
                                            .FirstOrDefaultAsync(cancellationToken)
                                            .ConfigureAwait(false);

            if (invoiceTable == null)
            {
                PolicyNumberGenerator invoiceNumberGenerator = new PolicyNumberGenerator()
                {
                    PolicyNumber = currentValue
                };
                await _context.PolicyNumberGenerators.AddAsync(invoiceNumberGenerator, cancellationToken)
                                                     .ConfigureAwait(false);
            }
            else
                invoiceTable.PolicyNumber = currentValue;

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return currentValue;
        }        
    }
}