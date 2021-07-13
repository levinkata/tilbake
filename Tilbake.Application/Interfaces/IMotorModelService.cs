using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IMotorModelService
    {
        Task<IEnumerable<MotorModelResource>> GetAllAsync();
        Task<MotorModelResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(MotorModelSaveResource resource);
        Task<int> UpdateAsync(MotorModelResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(MotorModelResource resource);
    }
}