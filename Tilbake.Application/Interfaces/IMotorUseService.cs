using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IMotorUseService
    {
        Task<MotorUsesViewModel> GetAllAsync();
        Task<MotorUseViewModel> GetAsync(Guid id);
        Task<int> AddAsync(MotorUseViewModel model);
        Task<int> UpdateAsync(MotorUseViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
