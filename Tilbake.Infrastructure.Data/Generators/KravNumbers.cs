using System;
using System.Linq;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Generators
{
    public static class KravNumbers
    {
        public static int Get(TilbakeDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            };

            return (context.KravNumberGenerators.Any()) ? context.KravNumberGenerators.Max(p => p.KravNumber) + 1 : 1;
        }
    }
}
