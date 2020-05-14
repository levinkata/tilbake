using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IRoofTypeService
    {
        Task<RoofTypesViewModel> GetAllAsync();
        Task<RoofTypeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(RoofTypeViewModel model);
        Task<int> UpdateAsync(RoofTypeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}