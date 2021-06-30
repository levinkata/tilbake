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
    public class RequisitionGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        private TilbakeDbContext _context;

        public RequisitionGenerator()
        {
        }

        /// <summary>
        /// Template method to perform value generation for RequisitionNumber.
        /// </summary>
        /// <param name="entry">In this case Requisition</param>
        /// <returns>Current invoice number</returns>
        public override int Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            _context = (TilbakeDbContext)entry.Context;

            var currentValue = _context.RequisitionNumberGenerators.Any() ?
                                    _context.RequisitionNumberGenerators
                                    .Max(p => p.RequisitionNumber) + 1 : 1;

            var invoiceTable = _context.RequisitionNumberGenerators
                                            .FirstOrDefault();

            if (invoiceTable == null)
            {
                RequisitionNumberGenerator invoiceNumberGenerator = new RequisitionNumberGenerator()
                {
                    RequisitionNumber = currentValue
                };
                _context.RequisitionNumberGenerators.Add(invoiceNumberGenerator);
            }
            else
                invoiceTable.RequisitionNumber = currentValue;

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

            var currentValue = _context.RequisitionNumberGenerators.Any() ?
                                    _context.RequisitionNumberGenerators
                                    .Max(p => p.RequisitionNumber) + 1 : 1;

            var invoiceTable = await _context.RequisitionNumberGenerators
                                            .FirstOrDefaultAsync(cancellationToken)
                                            .ConfigureAwait(false);

            if (invoiceTable == null)
            {
                RequisitionNumberGenerator invoiceNumberGenerator = new RequisitionNumberGenerator()
                {
                    RequisitionNumber = currentValue
                };
                await _context.RequisitionNumberGenerators.AddAsync(invoiceNumberGenerator, cancellationToken)
                                                     .ConfigureAwait(false);
            }
            else
                invoiceTable.RequisitionNumber = currentValue;

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return currentValue;
        }        
    }
}