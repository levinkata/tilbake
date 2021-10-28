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
        void Add(PortfolioAdministrationFeeSaveResource resource);
        void Update(PortfolioAdministrationFeeResource resource);
        void Delete(Guid id);
    }
}