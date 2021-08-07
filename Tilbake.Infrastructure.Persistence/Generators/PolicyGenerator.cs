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

        public PolicyGenerator()
        {
        }

        /// <summary>
        /// Template method to perform value generation for PolicyNumber.
        /// </summary>
        /// <param name="entry">In this case Policy</param>
        /// <returns>Current policy number</returns>
        public override int Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            var _context = (TilbakeDbContext)entry.Context;

            var currentValue = _context.PolicyNumberGenerators.Any() ?
                                        _context.PolicyNumberGenerators
                                        .AsNoTracking()
                                        .Max(p => p.PolicyNumber) + 1 : 1;

            var policyTable = _context.PolicyNumberGenerators
                                        .AsNoTracking()
                                        .OrderByDescending(e => e.PolicyNumber)
                                        .FirstOrDefault();

            if (policyTable == null)
            {
                PolicyNumberGenerator policyNumberGenerator = new()
                {
                    PolicyNumber = currentValue
                };

                _context.PolicyNumberGenerators.Add(policyNumberGenerator);
            }
            else
                policyTable.PolicyNumber = currentValue;

            return currentValue;
        }

        protected override async ValueTask<object> NextValueAsync(EntityEntry entry, CancellationToken cancellationToken = default)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            var _context = (TilbakeDbContext)entry.Context;

            var currentValue = _context.PolicyNumberGenerators.Any() ?
                                        _context.PolicyNumberGenerators
                                        .AsNoTracking()
                                        .Max(p => p.PolicyNumber) + 1 : 1;

            var policyTable = await _context.PolicyNumberGenerators
                                            .AsNoTracking()
                                            .OrderByDescending(e => e.PolicyNumber)
                                            .FirstOrDefaultAsync(cancellationToken);

            if (policyTable == null)
            {
                PolicyNumberGenerator policyNumberGenerator = new()
                {
                    PolicyNumber = currentValue
                };
                await _context.PolicyNumberGenerators.AddAsync(policyNumberGenerator, cancellationToken);
            }
            else
                policyTable.PolicyNumber = currentValue;

            return currentValue;
        }        
    }
}