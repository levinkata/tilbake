using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IPolitikkStatusService
    {
        Task<PolitikkStatusesViewModel> GetAllAsync();
        Task<PolitikkStatusViewModel> GetAsync(Guid id);
        Task<int> AddAsync(PolitikkStatusViewModel model);
        Task<int> UpdateAsync(PolitikkStatusViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
