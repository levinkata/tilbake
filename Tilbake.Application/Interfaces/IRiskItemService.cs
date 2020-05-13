using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IRiskItemService
    {
        Task<RiskItemsViewModel> GetAllAsync();
        Task<RiskItemViewModel> GetAsync(Guid id);
        Task<int> AddAsync(RiskItemViewModel model);
        Task<int> UpdateAsync(RiskItemViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
