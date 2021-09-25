using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IRatingMotorPremiumService
    {
        Task<IEnumerable<RatingMotorPremiumResource>> GetByInsurerAsync(Guid insurerId);
        Task<RatingMotorPremiumResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(RatingMotorPremiumSaveResource resource);
        Task<int> UpdateAsync(RatingMotorPremiumResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(RatingMotorPremiumResource resource);
    }
}
