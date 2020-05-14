using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IRegionService
    {
        Task<RegionsViewModel> GetAllAsync();
        Task<RegionViewModel> GetAsync(Guid id);
        Task<int> AddAsync(RegionViewModel model);
        Task<int> UpdateAsync(RegionViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}