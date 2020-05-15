using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IHouseService
    {
        Task<HousesViewModel> GetAllAsync();
        Task<HouseViewModel> GetAsync(Guid id);
        Task<int> AddAsync(HouseViewModel model);
        Task<int> UpdateAsync(HouseViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
