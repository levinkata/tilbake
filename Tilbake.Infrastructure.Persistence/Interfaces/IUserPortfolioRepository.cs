﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IUserPortfolioRepository : IRepository<AspnetUserPortfolio>
    {
        Task<IEnumerable<Portfolio>> GetByUserIdAsync(string aspNetUserId);
        Task<IEnumerable<Portfolio>> GetByNotUserIdAsync(string aspNetUserId);
    }
}
