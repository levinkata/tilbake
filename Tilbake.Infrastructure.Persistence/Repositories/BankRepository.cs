using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}