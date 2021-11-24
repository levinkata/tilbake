using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IPortfolioAdministrationFeeRepository : IRepository<PortfolioAdministrationFee>
    {
        Task<IEnumerable<PortfolioAdministrationFee>> GetByPortfolioId(Guid portfolioId);
    }
}
