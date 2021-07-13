using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IMotorService
    {
        Task<IEnumerable<MotorResource>> GetAllAsync();
        Task<MotorResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(MotorSaveResource resource);
        Task<int> UpdateAsync(MotorResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(MotorResource resource);
    }
}