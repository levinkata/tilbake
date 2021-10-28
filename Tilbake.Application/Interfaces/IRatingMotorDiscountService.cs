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
        void Add(RatingMotorDiscountSaveResource resource);
        void Update(RatingMotorDiscountResource resource);
        void Delete(Guid id);
    }
}
