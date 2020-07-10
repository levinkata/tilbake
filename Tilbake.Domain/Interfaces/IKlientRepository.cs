using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IKlientRepository : IRepository<Klient>
    {
        Task<IEnumerable<Klient>> GetByNameAsync(string klientName);
        Task<Klient> GetByIdNumberAsync(string idNumber);
        Task<Klient> GetByKlientNumberAsync(int klientNumber);
        Task AddToPortfolio(Guid portfolioId, Klient klient);
    }
}
