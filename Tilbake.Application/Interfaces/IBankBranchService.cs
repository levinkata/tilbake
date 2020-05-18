using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IBankBranchService
    {
        Task<BankBranchesViewModel> GetAllAsync();
        Task<BankBranchesViewModel> GetByBankAsync(Guid bankId);
        Task<BankBranchViewModel> GetAsync(Guid id);
        Task<int> AddAsync(BankBranchViewModel model);
        Task<int> UpdateAsync(BankBranchViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
