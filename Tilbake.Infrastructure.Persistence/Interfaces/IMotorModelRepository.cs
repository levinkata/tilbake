using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IMotorModelRepository : IRepository<MotorModel>
    {
        Task<IEnumerable<MotorModel>> GetByMotorMakeIdAsync(Guid motorMakeId);
    }    
}