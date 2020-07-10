using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class TitleRepository : Repository<Title>, ITitleRepository
    {
        public TitleRepository(TilbakeDbContext context) : base(context) { }
    }
}
