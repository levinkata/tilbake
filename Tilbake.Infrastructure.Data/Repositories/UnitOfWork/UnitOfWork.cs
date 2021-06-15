namespace Tilbake.Infrastructure.Data.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TilbakeDbContext _context;

        public UnitOfWork(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(true);
        }
    }
}