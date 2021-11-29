using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class AuditRepository : Repository<Audit>, IAuditRepository
    {
        public AuditRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}