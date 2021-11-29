using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class TravelBeneficiaryRepository : Repository<TravelBeneficiary>, ITravelBeneficiaryRepository
    {
        public TravelBeneficiaryRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}