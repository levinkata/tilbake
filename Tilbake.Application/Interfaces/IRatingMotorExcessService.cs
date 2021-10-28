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
        void Add(RatingMotorExcessSaveResource resource);
        void Update(RatingMotorExcessResource resource);
        void Delete(Guid id);
    }
}
