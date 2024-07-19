using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class CustomerCarrierRepository : Repository<CustomerCarrier>, ICustomerCarrierRepository
    {
        public CustomerCarrierRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<CustomerCarrier>> GetByCustomerId(Guid customerId)
        {
            return await _context.CustomerCarriers
                                .Where(r => r.CustomerId == customerId)
                                .Include(r => r.Carrier).AsNoTracking().ToListAsync();
        }
    }
}