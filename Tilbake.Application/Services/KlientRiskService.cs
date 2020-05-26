using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class KlientRiskService : IKlientRiskService
    {
        private readonly IKlientRiskRepository _klientRiskRepository;

        public KlientRiskService(IKlientRiskRepository klientRiskRepository)
        {
            _klientRiskRepository = klientRiskRepository;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _klientRiskRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<KlientRisksViewModel> GetAllAsync()
        {
            return new KlientRisksViewModel()
            {
                KlientRisks = await Task.Run(() => _klientRiskRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<KlientRiskViewModel> GetAsync(Guid id)
        {
            return new KlientRiskViewModel()
            {
                KlientRisk = await Task.Run(() => _klientRiskRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<KlientRisksViewModel> GetKlientRisks(Guid klientId)
        {
            return new KlientRisksViewModel()
            {
                KlientRisks = await Task.Run(() => _klientRiskRepository.GetKlientRisks(klientId)).ConfigureAwait(true)
            };
        }
    }
}
