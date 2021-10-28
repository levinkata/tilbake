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
        void Add(RatingMotorPremiumSaveResource resource);
        void Update(RatingMotorPremiumResource resource);
        void Delete(Guid id);
    }
}
