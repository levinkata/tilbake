﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IPortfolioPolicyFeeRepository : IRepository<PortfolioPolicyFee>
    {
        Task<IEnumerable<PortfolioPolicyFee>> GetByPortfolioId(Guid portfolioId);
    }
}
