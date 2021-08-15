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
        Task<int> AddAsync(PortfolioPolicyFeeSaveResource resource);
        Task<int> UpdateAsync(PortfolioPolicyFeeResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(PortfolioPolicyFeeResource resource);
    }
}