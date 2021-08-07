using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PortfolioClientRepository : Repository<PortfolioClient>, IPortfolioClientRepository
    {
        public PortfolioClientRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}