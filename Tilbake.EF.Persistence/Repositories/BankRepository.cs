using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}