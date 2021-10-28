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
        void Add(PremiumSaveResource resource);
        void Update(PremiumResource resource);
        void Delete(Guid id);
    }
}
