using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IPolitikkService
    {
        Task<PolitikksViewModel> GetAllAsync();
        Task<PolitikksViewModel> GetKlientPolitikkAsync(Guid klientId);
        Task<PolitikksViewModel> GetPortfolioPolitikkAsync(Guid portfolioId);
        Task<PolitikkViewModel> GetAsync(Guid id);
        Task<int> AddAsync(PolitikkViewModel model);
        Task<int> UpdateAsync(PolitikkViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
