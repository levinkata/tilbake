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
        Task<KlientResponse> GetAsync(Guid id, bool includeRelated);
        Task<KlientResponse> GetByIdNumberAsync(string idNumber);
        Task<KlientResponse> GetByKlientNumberAsync(int klientNumber);
        Task<KlientResponse> SaveAsync(Guid portfolioId, Klient klient);
        Task<KlientResponse> UpdateAsync(Guid id, Klient klient);
        Task<KlientResponse> DeleteAsync(Guid id);
    }
}
