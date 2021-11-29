using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}