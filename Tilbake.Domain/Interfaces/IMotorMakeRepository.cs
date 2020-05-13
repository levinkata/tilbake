using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IMotorMakeRepository
    {
        Task<IEnumerable<MotorMake>> GetAllAsync();
        Task<MotorMake> GetAsync(Guid id);
        Task<int> AddAsync(MotorMake motorMake);
        Task<int> UpdateAsync(MotorMake motorMake);
        Task<int> DeleteAsync(Guid id);
    }
}
