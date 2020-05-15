using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IPremiumTypeService
    {
        Task<PremiumTypesViewModel> GetAllAsync();
        Task<PremiumTypeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(PremiumTypeViewModel model);
        Task<int> UpdateAsync(PremiumTypeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
