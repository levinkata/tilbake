using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IWallTypeService
    {
        Task<WallTypesViewModel> GetAllAsync();
        Task<WallTypeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(WallTypeViewModel model);
        Task<int> UpdateAsync(WallTypeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}