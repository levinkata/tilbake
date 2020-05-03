using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetAllAsync();
        Task<Bank> GetAsync(Guid id);
        Task<int> AddAsync(Bank bank);
        Task<int> UpdateAsync(Bank bank);
        Task<int> DeleteAsync(Guid id);
    }
}
