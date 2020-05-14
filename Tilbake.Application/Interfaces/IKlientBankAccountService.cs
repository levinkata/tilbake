using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IKlientBankAccountService
    {
        Task<KlientBankAccountsViewModel> GetAllAsync();
        Task<KlientBankAccountsViewModel> GetKlientBankAccounts(Guid klientId);
        Task<KlientBankAccountViewModel> GetAsync(Guid klientId, Guid bankAccountId);
        Task<int> AddAsync(KlientBankAccountViewModel model);
        Task<int> UpdateAsync(KlientBankAccountViewModel model);
        Task<int> DeleteAsync(Guid klientId, Guid bankAccountId);
    }
}
