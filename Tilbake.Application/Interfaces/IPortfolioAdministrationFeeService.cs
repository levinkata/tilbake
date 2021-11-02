using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPortfolioAdministrationFeeService
    {
        Task<IEnumerable<PortfolioAdministrationFeeResource>> GetAllAsync();
        Task<IEnumerable<PortfolioAdministrationFeeResource>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<PortfolioAdministrationFeeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PortfolioAdministrationFeeSaveResource resource);
        Task<int> UpdateAsync(PortfolioAdministrationFeeResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}