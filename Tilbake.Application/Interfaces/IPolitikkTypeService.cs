using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IPolitikkTypeService
    {
        Task<PolitikkTypesViewModel> GetAllAsync();
        Task<PolitikkTypeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(PolitikkTypeViewModel model);
        Task<int> UpdateAsync(PolitikkTypeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
