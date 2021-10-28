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
        void Add(MotorMakeSaveResource resource);
        void Update(MotorMakeResource resource);
        void Delete(Guid id);
    }
}