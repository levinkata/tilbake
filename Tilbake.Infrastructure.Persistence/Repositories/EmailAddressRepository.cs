using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class EmailAddressRepository : Repository<EmailAddress>, IEmailAddressRepository
    {
        public EmailAddressRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
