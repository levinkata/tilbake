using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ICommissionRateService
    {
        Task<IEnumerable<CommissionRateResource>> GetAllAsync();
        Task<CommissionRateResource> GetByRisk(string riskName);
        Task<CommissionRateResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(CommissionRateSaveResource resource);
        Task<int> UpdateAsync(CommissionRateResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}