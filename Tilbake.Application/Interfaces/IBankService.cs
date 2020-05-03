using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IBankService
    {
        Task<BanksViewModel> GetAllAsync();
        Task<BankViewModel> GetAsync(Guid id);
        Task<int> AddAsync(BankViewModel model);
        Task<int> UpdateAsync(BankViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
