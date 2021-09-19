using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.Infrastructure.Persistence.Generators
{
    public class RequisitionGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;

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

            var _context = (TilbakeDbContext)entry.Context;

                var currentValue = _context.RequisitionNumberGenerators.Any() ?
                                        _context.RequisitionNumberGenerators
                                        .AsNoTracking()
                                        .Max(p => p.RequisitionNumber) + 1 : 1;

            var invoiceTable = _context.RequisitionNumberGenerators
                                        .AsNoTracking()
                                        .OrderByDescending(e => e.RequisitionNumber)
                                        .FirstOrDefault();

            if (invoiceTable == null)
            {
                RequisitionNumberGenerator invoiceNumberGenerator = new()
                {
                    RequisitionNumber = currentValue
                };
                _context.RequisitionNumberGenerators.Add(invoiceNumberGenerator);
            }
            else
                invoiceTable.RequisitionNumber = currentValue;

            return currentValue;
        }

        protected override async ValueTask<object> NextValueAsync(EntityEntry entry, CancellationToken cancellationToken = default)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            var _context = (TilbakeDbContext)entry.Context;

            var currentValue = _context.RequisitionNumberGenerators.Any() ?
                                    _context.RequisitionNumberGenerators
                                    .AsNoTracking()
                                    .Max(p => p.RequisitionNumber) + 1 : 1;

            var invoiceTable = await _context.RequisitionNumberGenerators
                                                .AsNoTracking()
                                                .OrderByDescending(e => e.RequisitionNumber)
                                                .FirstOrDefaultAsync(cancellationToken);

            if (invoiceTable == null)
            {
                RequisitionNumberGenerator invoiceNumberGenerator = new()
                {
                    RequisitionNumber = currentValue
                };
                await _context.RequisitionNumberGenerators.AddAsync(invoiceNumberGenerator, cancellationToken);
            }
            else
                invoiceTable.RequisitionNumber = currentValue;

            return currentValue;
        }        
    }
}