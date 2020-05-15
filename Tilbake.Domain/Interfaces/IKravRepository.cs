using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IKravRepository
    {
        Task<IEnumerable<Krav>> GetAllAsync();
        Task<IEnumerable<Krav>> GetByPortfolioKlientAsync(Guid portfolioKlientId);
        Task<IEnumerable<Krav>> GetByPolitikkRiskAsync(Guid politikRiskId);
        Task<Krav> GetAsync(int id);
        Task<int> AddAsync(Krav krav);
        Task<int> UpdateAsync(Krav krav);
        Task<int> DeleteAsync(int id);
    }
}
