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
        Task AddAsync(Guid portfolioId, Klient klient);
        void UpdateAsync(Klient klient);
        void DeleteAsync(Klient klient);
    }
}
