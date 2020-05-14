using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface ICoverTypeService
    {
        Task<CoverTypesViewModel> GetAllAsync();
        Task<CoverTypeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(CoverTypeViewModel model);
        Task<int> UpdateAsync(CoverTypeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
