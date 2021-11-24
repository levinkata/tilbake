using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;

namespace Tilbake.EF.Persistence.Repositories
{
    public class IncidentRepository : Repository<Incident>, IIncidentRepository
    {
        public IncidentRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}