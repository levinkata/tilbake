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
            
            var _context = (TilbakeDbContext)entry.Context;

            var currentValue = _context.ClientNumberGenerators.Any() ?
                                    _context.ClientNumberGenerators
                                    .AsNoTracking()
                                    .Max(p => p.ClientNumber) + 1 : 1;

            var clientTable = _context.ClientNumberGenerators
                                        .AsNoTracking()
                                        .OrderByDescending(n => n.ClientNumber)
                                        .FirstOrDefault();

            if (clientTable == null)
            {
                ClientNumberGenerator clientNumberGenerator = new()
                {
                    ClientNumber = currentValue
                };
                _context.ClientNumberGenerators.Add(clientNumberGenerator);
            }
            else
                clientTable.ClientNumber = currentValue;

            return currentValue;
        }

        protected override async ValueTask<object> NextValueAsync(EntityEntry entry, CancellationToken cancellationToken = default)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            var _context = (TilbakeDbContext)entry.Context;

            var currentValue = _context.ClientNumberGenerators.Any() ?
                                    _context.ClientNumberGenerators
                                    .AsNoTracking()
                                    .Max(p => p.ClientNumber) + 1 : 1;

            var clientTable = await _context.ClientNumberGenerators
                                            .AsNoTracking()
                                            .OrderByDescending(n => n.ClientNumber)
                                            .FirstOrDefaultAsync(cancellationToken);

            if (clientTable == null)
            {
                ClientNumberGenerator clientNumberGenerator = new()
                {
                    ClientNumber = currentValue
                };
                await _context.ClientNumberGenerators.AddAsync(clientNumberGenerator, cancellationToken);
            }
            else
                clientTable.ClientNumber = currentValue;

            return currentValue;
        }        
    }
}