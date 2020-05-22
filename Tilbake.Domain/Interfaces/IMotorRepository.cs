using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IMotorRepository
    {
        Task<IEnumerable<Motor>> GetAllAsync();
        Task<IEnumerable<Motor>> GetByKlientAsync(Guid klientId);
        Task<Motor> GetByRegNumberAsync(string regNumber);
        Task<Motor> GetByEngineNumberAsync(string engineNumber);
        Task<Motor> GetByChassissNumberAsync(string chassissNumber);
        Task<Motor> GetAsync(Guid id);
        Task<int> AddAsync(Guid klientId, Motor motor);
        Task<int> UpdateAsync(Motor motor);
        Task<int> DeleteAsync(Guid id);
        Task<bool> RegNumberExists(Guid id, string regNumber);
        Task<bool> EngineNumberExists(Guid id, string engineNumber);
        Task<bool> ChassissNumberExists(Guid id, string chassissNumber);
    }
}
