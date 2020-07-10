using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface IKlientService
    {
        Task<IEnumerable<Klient>> GetAllAsync();
        Task<IEnumerable<Klient>> GetByNameAsync(string klientName);
        Task<KlientResponse> GetAsync(Guid id);
        Task<KlientResponse> GetByIdNumberAsync(string idNumber);
        Task<KlientResponse> GetByKlientNumberAsync(int klientNumber);
        Task<KlientResponse> AddAsync(Klient klient);
        Task<KlientResponse> AddToPortfolio(Guid portfolioId, Klient klient);
        Task<KlientResponse> UpdateAsync(Guid id, Klient klient);
        Task<KlientResponse> DeleteAsync(Guid id);
    }
}
