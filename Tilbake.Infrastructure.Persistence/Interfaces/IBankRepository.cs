using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetAllAsync();
        Task<Bank> GetByIdAsync(Guid id);
        Task<Bank> AddAsync(Bank bank);
        Task <IEnumerable<Bank>> AddRangeAsync (IEnumerable<Bank> banks);
        Task<Bank> UpdateAsync(Bank bank);
        Task<Bank> DeleteAsync(Guid id);
        Task<Bank> DeleteAsync(Bank bank);
        Task<IEnumerable<Bank>> DeleteRangeAsync(IEnumerable<Bank> banks);  
    }    
}