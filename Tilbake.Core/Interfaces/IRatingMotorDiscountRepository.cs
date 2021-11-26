using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IRatingMotorDiscountRepository : IRepository<RatingMotorDiscount>
    {
        Task<IEnumerable<RatingMotorDiscount>> GetByInsurer(Guid insurerId);
    }
}
