using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class EmailAddressRepository : Repository<EmailAddress>, IEmailAddressRepository
    {
        public EmailAddressRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
