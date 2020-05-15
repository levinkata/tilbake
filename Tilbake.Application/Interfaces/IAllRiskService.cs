using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IAllRiskService
    {
        Task<AllRisksViewModel> GetAllAsync();
        Task<AllRiskViewModel> GetAsync(Guid id);
        Task<int> AddAsync(AllRiskViewModel model);
        Task<int> UpdateAsync(AllRiskViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
