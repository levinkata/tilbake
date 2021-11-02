using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IMotorMakeService
    {
        Task<IEnumerable<MotorMakeResource>> GetAllAsync();
        Task<MotorMakeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(MotorMakeSaveResource resource);
        Task<int> UpdateAsync(MotorMakeResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}