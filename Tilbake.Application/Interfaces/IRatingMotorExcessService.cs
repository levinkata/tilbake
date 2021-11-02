using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IRatingMotorExcessService
    {
        Task<IEnumerable<RatingMotorExcessResource>> GetByInsurerAsync(Guid insurerId);
        Task<RatingMotorExcessResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(RatingMotorExcessSaveResource resource);
        Task<int> UpdateAsync(RatingMotorExcessResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
