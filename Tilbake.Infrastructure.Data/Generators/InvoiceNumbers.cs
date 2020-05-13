using System;
using System.Linq;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Generators
{
    public static class InvoiceNumbers
    {
        public static int Get(TilbakeDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            };

            return (context.InvoiceNumberGenerators.Any()) ? context.InvoiceNumberGenerators.Max(p => p.InvoiceNumber) + 1 : 1;
        }
    }
}
