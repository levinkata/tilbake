using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class TitleRepository : Repository<Title>, ITitleRepository
    {
        public TitleRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}