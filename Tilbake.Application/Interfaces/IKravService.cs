using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IKravService
    {
        Task<KravsViewModel> GetAllAsync();
        Task<KravsViewModel> GetByPortfolioKlientAsync(Guid portfolioKlientId);
        Task<KravsViewModel> GetByPolitikkRiskAsync(Guid politikRiskId);
        Task<KravViewModel> GetAsync(int id);
        Task<int> AddAsync(KravViewModel model);
        Task<int> UpdateAsync(KravViewModel model);
        Task<int> DeleteAsync(int id);
    }
}
