using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IRatingMotorDiscountService
    {
        Task<IEnumerable<RatingMotorDiscountResource>> GetByInsurerAsync(Guid insurerId);
        Task<RatingMotorDiscountResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(RatingMotorDiscountSaveResource resource);
        Task<int> UpdateAsync(RatingMotorDiscountResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
