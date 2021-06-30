using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IBankRepository
    {
        Task<IQueryable<Bank>> GetAllAsync();
        Task<Bank> GetByIdAsync(Guid id);
        Task<Bank> AddAsync(Bank bank);
        Task <IQueryable<Bank>> AddRangeAsync (IQueryable<Bank> banks);
        Task<Bank> UpdateAsync(Bank bank);
        Task<Bank> DeleteAsync(Guid id);
        Task<Bank> DeleteAsync(Bank bank);
        Task<IQueryable<Bank>> DeleteRangeAsync(IQueryable<Bank> banks);  
    }    
}