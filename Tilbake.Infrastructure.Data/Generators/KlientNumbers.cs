using System;
using System.Linq;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Generators
{
    public static class KlientNumbers
    {
        public static int Get(TilbakeDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            };

            return (context.KlientNumberGenerators.Any()) ? context.KlientNumberGenerators.Max(p => p.KlientNumber) + 1 : 1;
        }
    }
}
