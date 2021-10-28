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
        void Add(RatingMotorSaveResource resource);
        void Update(RatingMotorResource resource);
        void Delete(Guid id);
    }
}
