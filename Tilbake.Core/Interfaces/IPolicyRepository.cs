using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IPolicyRepository : IRepository<Policy>
    {
        Task<IEnumerable<Policy>> GetByPorfolioCustomerId(Guid portfolioCustomerId);
        Task<Policy> GetCurrentPolicy(Guid portfolioCustomerId);
    }    
}