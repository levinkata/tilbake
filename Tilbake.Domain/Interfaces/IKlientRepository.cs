using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IKlientRepository
    {
        Task<IEnumerable<Klient>> GetAllAsync();
        Task<IEnumerable<Klient>> GetByNameAsync(string klientName);
        Task<Klient> GetAsync(Guid id, bool includeRelated);
        Task<Klient> GetByIdNumberAsync(string idNumber);
        Task<Klient> GetByKlientNumberAsync(int klientNumber);
        Task<int> AddAsync(Guid portfolioId, Klient klient);
        Task<int> UpdateAsync(Klient klient);
        Task<int> DeleteAsync(Guid id);
    }
}
