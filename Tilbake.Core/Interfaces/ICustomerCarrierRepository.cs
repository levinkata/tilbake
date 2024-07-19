using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface ICustomerCarrierRepository : IRepository<CustomerCarrier>
    {
        Task<IEnumerable<CustomerCarrier>> GetByCustomerId(Guid customerId);
    }
}