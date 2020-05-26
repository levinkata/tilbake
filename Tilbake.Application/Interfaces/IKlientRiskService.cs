using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IKlientRiskService
    {
        Task<KlientRisksViewModel> GetAllAsync();
        Task<KlientRisksViewModel> GetKlientRisks(Guid klientId);
        Task<KlientRiskViewModel> GetAsync(Guid id);
        Task<int> DeleteAsync(Guid id);
    }
}
