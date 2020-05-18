using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IMotorModelRepository
    {
        Task<IEnumerable<MotorModel>> GetAllAsync();
        Task<IEnumerable<MotorModel>> GetByMotorMakeAsync(Guid motorMakeId);        
        Task<MotorModel> GetAsync(Guid id);
        Task<int> AddAsync(MotorModel motorModel);
        Task<int> UpdateAsync(MotorModel motorModel);
        Task<int> DeleteAsync(Guid id);
    }
}
