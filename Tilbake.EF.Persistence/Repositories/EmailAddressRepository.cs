using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class EmailAddressRepository : Repository<EmailAddress>, IEmailAddressRepository
    {
        public EmailAddressRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
