using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly TilbakeDbContext _context;

        public BaseRepository(TilbakeDbContext context)
        {
            _context = context;
        }
    }
}
