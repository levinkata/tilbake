using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IRatingMotorService
    {
        Task<IEnumerable<RatingMotorResource>> GetByInsurerAsync(Guid insurerId);
        Task<RatingMotorResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(RatingMotorSaveResource resource);
        Task<int> UpdateAsync(RatingMotorResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
