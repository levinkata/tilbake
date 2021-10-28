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
        Task<IEnumerable<MotorModelResource>> GetByMotorMakeIdAsync(Guid motorMakeId);
        void Add(MotorModelSaveResource resource);
        void Update(MotorModelResource resource);
        void Delete(Guid id);
    }
}