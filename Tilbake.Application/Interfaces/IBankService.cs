using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface IBankService
    {
        Task<IEnumerable<Bank>> GetAllAsync();
        Task<BankResponse> GetAsync(Guid id);
        Task<BankResponse> SaveAsync(Bank bank);
        Task<BankResponse> UpdateAsync(Guid id, Bank bank);
        Task<BankResponse> DeleteAsync(Guid id);         
    }
}