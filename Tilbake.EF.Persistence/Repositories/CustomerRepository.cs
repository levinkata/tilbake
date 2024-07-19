using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<Customer> GetByIdNumber(string idNumber)
        {
            return await _context.Customers
                                .Where(c => c.IdNumber == idNumber)
                                .Include(c => c.CustomerType)
                                .Include(c => c.Country)
                                .Include(c => c.IdDocumentType)
                                .Include(c => c.Gender)
                                .Include(c => c.MaritalStatus)
                                .Include(c => c.Occupation)
                                .Include(c => c.Title).FirstOrDefaultAsync();
        }
    }
}