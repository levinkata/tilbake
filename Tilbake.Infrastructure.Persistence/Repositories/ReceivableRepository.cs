using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ReceivableRepository : Repository<Receivable>, IReceivableRepository
    {
        public ReceivableRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
