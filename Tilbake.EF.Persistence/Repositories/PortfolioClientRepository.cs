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
    public class PortfolioCustomerRepository : Repository<PortfolioCustomer>, IPortfolioCustomerRepository
    {
        public PortfolioCustomerRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Customer>> GetByPortfolioId(Guid portfolioId)
        {
            return await _context.Customers
                                .Include(c => c.EmailAddresses)
                                .Include(c => c.MobileNumbers)
                                .Include(c => c.CustomerCarriers)
                                .Include(c => c.CustomerType)
                                .Include(c => c.Country)
                                .Include(c => c.IdDocumentType)
                                .Include(c => c.Gender)
                                .Include(c => c.MaritalStatus)
                                .Include(c => c.Occupation)
                                .Include(c => c.Title)
                                .Where(e => e.PortfolioCustomers.Any(p => p.PortfolioId == portfolioId))
                                .OrderBy(n => n.LastName)
                                .AsSplitQuery().AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetByPortfolioIdAndCustomerId(Guid portfolioId, Guid customerId)
        {
            return await _context.Customers
                                .Where(e => e.PortfolioCustomers.Any(p => p.PortfolioId == portfolioId && p.CustomerId == customerId))
                                .Include(c => c.Addresses)
                                .Include(c => c.EmailAddresses)
                                .Include(c => c.MobileNumbers)
                                .Include(c => c.CustomerCarriers)
                                .Include(c => c.CustomerType)
                                .Include(c => c.Country)
                                .Include(c => c.IdDocumentType)
                                .Include(c => c.Gender)
                                .Include(c => c.MaritalStatus)
                                .Include(c => c.Occupation)
                                .Include(c => c.Title)
                                .FirstOrDefaultAsync();
        }

        public Task<Customer> GetByPortfolioIdAndIdNumber(Guid portfolioId, string idNumber)
        {
            throw new NotImplementedException();
        }
    }
}