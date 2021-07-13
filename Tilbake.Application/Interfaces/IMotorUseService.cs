using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IMotorUseService
    {
        Task<IEnumerable<MotorUseResource>> GetAllAsync();
        Task<MotorUseResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(MotorUseSaveResource resource);
        Task<int> UpdateAsync(MotorUseResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(MotorUseResource resource);
    }
}