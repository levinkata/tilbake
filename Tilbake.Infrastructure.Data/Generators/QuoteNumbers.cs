using System;
using System.Linq;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Generators
{
    public static class QuoteNumbers
    {
        public static int Get(TilbakeDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            };

            return (context.QuoteNumberGenerators.Any()) ? context.QuoteNumberGenerators.Max(p => p.QuoteNumber) + 1 : 1;
        }
    }
}
