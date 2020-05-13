using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IMotorMakeService
    {
        Task<MotorMakesViewModel> GetAllAsync();
        Task<MotorMakeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(MotorMakeViewModel model);
        Task<int> UpdateAsync(MotorMakeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
