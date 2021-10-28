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
        void Add(MotorSaveResource resource);
        void Update(MotorResource resource);
        void Delete(Guid id);
    }
}