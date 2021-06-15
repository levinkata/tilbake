using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(TilbakeDbContext context) : base(context)
        {

        }        
    }
}