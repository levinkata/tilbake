using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IKlientService
    {
        Task<KlientsViewModel> GetAllAsync();
        Task<KlientsViewModel> GetByNameAsync(string klientName);
        Task<KlientViewModel> GetAsync(Guid id);
        Task<KlientViewModel> GetByIdNumberAsync(string idNumber);
        Task<KlientViewModel> GetByKlientNumberAsync(int klientNumber);
        Task<int> AddAsync(KlientViewModel model);
        Task<int> UpdateAsync(KlientViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
