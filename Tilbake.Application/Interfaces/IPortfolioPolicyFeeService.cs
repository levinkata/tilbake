using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPortfolioPolicyFeeService
    {
        Task<IEnumerable<PortfolioPolicyFeeResource>> GetAllAsync();
        Task<IEnumerable<PortfolioPolicyFeeResource>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<PortfolioPolicyFeeResource> GetByIdAsync(Guid id);
        void Add(PortfolioPolicyFeeSaveResource resource);
        void Update(PortfolioPolicyFeeResource resource);
        void Delete(Guid id);
    }
}