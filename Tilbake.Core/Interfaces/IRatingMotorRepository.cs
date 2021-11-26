using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IRatingMotorRepository : IRepository<RatingMotor>
    {
        Task<IEnumerable<RatingMotor>> GetByInsurerId(Guid insurerId);
    }
}
