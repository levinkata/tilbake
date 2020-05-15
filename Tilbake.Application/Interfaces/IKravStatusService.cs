using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IKravStatusService
    {
        Task<KravStatusesViewModel> GetAllAsync();
        Task<KravStatusViewModel> GetAsync(Guid id);
        Task<int> AddAsync(KravStatusViewModel model);
        Task<int> UpdateAsync(KravStatusViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
