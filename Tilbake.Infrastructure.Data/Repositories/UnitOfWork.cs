using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TilbakeDbContext _context;

        public UnitOfWork(TilbakeDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(true);
        }
    }
}
