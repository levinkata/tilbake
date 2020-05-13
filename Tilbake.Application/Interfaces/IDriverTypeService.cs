using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IDriverTypeService
    {
        Task<DriverTypesViewModel> GetAllAsync();
        Task<DriverTypeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(DriverTypeViewModel model);
        Task<int> UpdateAsync(DriverTypeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
