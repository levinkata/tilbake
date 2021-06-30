using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface IBankService
    {
        Task<IEnumerable<Bank>> GetAllAsync();
        Task<BankResponse> GetByIdAsync(Guid id);
        Task<BankResponse> AddAsync(Bank bank);
        Task<BankResponse> UpdateAsync(Guid id, Bank bank);
        Task<BankResponse> DeleteAsync(Guid id);
        Task<BankResponse> DeleteAsync(Bank bank);
    }
}