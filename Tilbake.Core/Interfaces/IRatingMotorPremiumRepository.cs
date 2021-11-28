using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IRatingMotorPremiumRepository : IRepository<RatingMotorPremium>
    {
        Task<IEnumerable<RatingMotorPremium>> GetByInsurerId(Guid insurerId);
    }
}
