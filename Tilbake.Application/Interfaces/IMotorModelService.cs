using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IMotorModelService
    {
        Task<MotorModelsViewModel> GetAllAsync();
        Task<MotorModelsViewModel> GetByMotorMakeAsync(Guid motorMakeId);
        Task<MotorModelViewModel> GetAsync(Guid id);
        Task<int> AddAsync(MotorModelViewModel model);
        Task<int> UpdateAsync(MotorModelViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
