using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPremiumService
    {
        Task<IEnumerable<PremiumResource>> GetAllAsync();
        Task<IEnumerable<PremiumResource>> GetByPolicyIdAsync(Guid policyId);
        Task<PremiumResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PremiumSaveResource resource);
        Task<int> UpdateAsync(PremiumResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
