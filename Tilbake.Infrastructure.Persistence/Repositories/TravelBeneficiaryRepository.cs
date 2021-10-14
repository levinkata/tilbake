using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class TravelBeneficiaryRepository : Repository<TravelBeneficiary>, ITravelBeneficiaryRepository
    {
        public TravelBeneficiaryRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}