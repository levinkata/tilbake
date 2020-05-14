using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class KlientBankAccountService : IKlientBankAccountService
    {
        private readonly IKlientBankAccountRepository _klientBankAccountRepository;

        public KlientBankAccountService(IKlientBankAccountRepository klientBankAccountRepository)
        {
            _klientBankAccountRepository = klientBankAccountRepository;

        }
        public async Task<int> AddAsync(KlientBankAccountViewModel model)
        {
            return await Task.Run(() => _klientBankAccountRepository.AddAsync(model.KlientID, model.BankAccount)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid klientId, Guid bankAccountId)
        {
            return await Task.Run(() => _klientBankAccountRepository.DeleteAsync(klientId, bankAccountId)).ConfigureAwait(true);
        }

        public async Task<KlientBankAccountsViewModel> GetAllAsync()
        {
            return new KlientBankAccountsViewModel()
            {
                KlientBankAccounts= await Task.Run(() => _klientBankAccountRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<KlientBankAccountViewModel> GetAsync(Guid klientId, Guid bankAccountId)
        {
            return new KlientBankAccountViewModel()
            {
                KlientBankAccount = await Task.Run(() => _klientBankAccountRepository.GetAsync(klientId, bankAccountId)).ConfigureAwait(true)
            };
        }

        public async Task<KlientBankAccountsViewModel> GetKlientBankAccounts(Guid klientId)
        {
            return new KlientBankAccountsViewModel()
            {
                KlientBankAccounts = await Task.Run(() => _klientBankAccountRepository.GetKlientBankAccounts(klientId)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(KlientBankAccountViewModel model)
        {
            return await Task.Run(() => _klientBankAccountRepository.UpdateAsync(model.BankAccount)).ConfigureAwait(true);
        }
    }
}
