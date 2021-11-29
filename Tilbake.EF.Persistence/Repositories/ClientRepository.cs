using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<Client> GetByIdNumber(string idNumber)
        {
            return await _context.Clients
                                .Where(c => c.IdNumber == idNumber)
                                .Include(c => c.ClientType)
                                .Include(c => c.Country)
                                .Include(c => c.IdDocumentType)
                                .Include(c => c.Gender)
                                .Include(c => c.MaritalStatus)
                                .Include(c => c.Occupation)
                                .Include(c => c.Title).FirstOrDefaultAsync();
        }
    }
}