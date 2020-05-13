using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IMotorUseRepository
    {
        Task<IEnumerable<MotorUse>> GetAllAsync();
        Task<MotorUse> GetAsync(Guid id);
        Task<int> AddAsync(MotorUse motorUse);
        Task<int> UpdateAsync(MotorUse motorUse);
        Task<int> DeleteAsync(Guid id);
    }
}
