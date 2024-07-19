using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IPortfolioCustomerRepository : IRepository<PortfolioCustomer>
    {
        Task<IEnumerable<Customer>> GetByPortfolioId(Guid portfolioId);
        Task<Customer> GetByPortfolioIdAndIdNumber(Guid portfolioId, string idNumber);
        Task<Customer> GetByPortfolioIdAndCustomerId(Guid portfolioId, Guid customerId);
    }
}