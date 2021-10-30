using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class TravelBeneficiaryRepository : Repository<TravelBeneficiary>, ITravelBeneficiaryRepository
    {
        public TravelBeneficiaryRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}