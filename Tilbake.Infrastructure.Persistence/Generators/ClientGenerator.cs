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
        /// <param name="entry">In this case Client</param>
        /// <returns>Current client number</returns>
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

            var clientTable = _context.ClientNumberGenerators
                                            .FirstOrDefault();

            if (clientTable == null)
            {
                ClientNumberGenerator clientNumberGenerator = new ClientNumberGenerator()
                {
                    ClientNumber = currentValue
                };
                _context.ClientNumberGenerators.Add(clientNumberGenerator);
            }
            else
                clientTable.ClientNumber = currentValue;

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

            var clientTable = await _context.ClientNumberGenerators
                                            .FirstOrDefaultAsync(cancellationToken)
                                            .ConfigureAwait(false);

            if (clientTable == null)
            {
                ClientNumberGenerator clientNumberGenerator = new ClientNumberGenerator()
                {
                    ClientNumber = currentValue
                };
                await _context.ClientNumberGenerators.AddAsync(clientNumberGenerator, cancellationToken)
                                                     .ConfigureAwait(false);
            }
            else
                clientTable.ClientNumber = currentValue;

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return currentValue;
        }        
    }
}