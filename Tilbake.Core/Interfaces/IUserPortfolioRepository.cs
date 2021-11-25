using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IUserPortfolioRepository : IRepository<AspnetUserPortfolio>
    {
        Task<IEnumerable<Portfolio>> GetByNotUserId(string aspNetUserId);
        Task<IEnumerable<Portfolio>> GetByUserId(string aspNetUserId);
    }
}
