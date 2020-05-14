using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IKlientBankAccountRepository
    {
        Task<IEnumerable<KlientBankAccount>> GetAllAsync();
        Task<IEnumerable<KlientBankAccount>> GetKlientBankAccounts(Guid klientId);
        Task<KlientBankAccount> GetAsync(Guid klientId, Guid bankAccountId);
        Task<int> AddAsync(Guid klientId, BankAccount bankAccount);
        Task<int> UpdateAsync(BankAccount bankAccount);
        Task<int> DeleteAsync(Guid klientId, Guid bankAccountId);
    }
}