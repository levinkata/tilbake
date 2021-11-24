using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;

namespace Tilbake.EF.Persistence.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}