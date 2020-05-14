using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IPolitikkRepository
    {
        Task<IEnumerable<Politikk>> GetAllAsync();
        Task<IEnumerable<Politikk>> GetKlientPolitikkAsync(Guid klientId);
        Task<IEnumerable<Politikk>> GetPortfolioPolitikkAsync(Guid portfolioId);
        Task<Politikk> GetAsync(Guid id);
        Task<int> AddAsync(Politikk politikk);
        Task<int> UpdateAsync(Politikk politikk);
        Task<int> DeleteAsync(Guid id);
    }
}
