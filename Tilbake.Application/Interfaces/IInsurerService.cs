using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IInsurerService
    {
        Task<InsurersViewModel> GetAllAsync();
        Task<InsurerViewModel> GetAsync(Guid id);
        Task<int> AddAsync(InsurerViewModel model);
        Task<int> UpdateAsync(InsurerViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
