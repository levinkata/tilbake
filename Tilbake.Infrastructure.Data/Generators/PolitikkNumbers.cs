using System;
using System.Linq;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Generators
{
    public static class PolitikkNumbers
    {
        public static int Get(TilbakeDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            };

            return (context.PolitikkNumberGenerators.Any()) ? context.PolitikkNumberGenerators.Max(p => p.PolitikkNumber) + 1 : 1;
        }
    }
}
