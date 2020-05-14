using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IPolitikkRiskService
    {
        Task<PolitikkRisksViewModel> GetAllAsync(Guid politikkId);
        Task<PolitikkRiskViewModel> GetAsync(Guid id);
        Task<int> AddAsync(PolitikkRiskViewModel model);
        Task<int> UpdateAsync(PolitikkRiskViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
