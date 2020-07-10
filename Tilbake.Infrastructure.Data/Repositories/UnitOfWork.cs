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
            Klient = new KlientRepository(_context);
            Title = new TitleRepository(_context);
        }

        public IKlientRepository Klient { get; private set; }
        public ITitleRepository Title { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(true);
        }
    }
}
