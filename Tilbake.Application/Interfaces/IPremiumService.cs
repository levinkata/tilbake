using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IPremiumService
    {
        Task<PremiumsViewModel> GetAllAsync();
        Task<PremiumViewModel> GetAsync(Guid id);
        Task<int> AddAsync(PremiumViewModel model);
        Task<int> UpdateAsync(PremiumViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
