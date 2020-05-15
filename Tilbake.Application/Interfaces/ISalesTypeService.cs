using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface ISalesTypeService
    {
        Task<SalesTypesViewModel> GetAllAsync();
        Task<SalesTypeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(SalesTypeViewModel model);
        Task<int> UpdateAsync(SalesTypeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
