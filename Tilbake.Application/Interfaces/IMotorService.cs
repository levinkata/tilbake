using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IMotorService
    {
        Task<MotorsViewModel> GetAllAsync();
        Task<MotorViewModel> GetByRegNumberAsync(string regNumber);
        Task<MotorViewModel> GetByEngineNumberAsync(string engineNumber);
        Task<MotorViewModel> GetByChassissNumberAsync(string chassissNumber);
        Task<MotorViewModel> GetMotorAsync(Guid id);
        Task<int> AddAsync(MotorViewModel model);
        Task<int> UpdateAsync(MotorViewModel model);
        Task<int> DeleteAsync(Guid id);
        Task<bool> RegNumberExists(Guid id, string regNumber);
        Task<bool> EngineNumberExists(Guid id, string engineNumber);
        Task<bool> ChassissNumberExists(Guid id, string chassissNumber);
    }
}
