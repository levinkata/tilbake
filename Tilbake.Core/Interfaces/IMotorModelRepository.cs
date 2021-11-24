using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IMotorModelRepository : IRepository<MotorModel>
    {
        Task<IEnumerable<MotorModel>> GetByMotorMakeId(Guid motorMakeId);
    }    
}