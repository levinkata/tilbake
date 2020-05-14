using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class PolitikkRiskService : IPolitikkRiskService
    {
        private readonly IPolitikkRiskRepository _politikkRiskRepository;

        public PolitikkRiskService(IPolitikkRiskRepository politikkRiskRepository)
        {
            _politikkRiskRepository = politikkRiskRepository;
        }

        public async Task<int> AddAsync(PolitikkRiskViewModel model)
        {
            return await Task.Run(() => _politikkRiskRepository.AddAsync(model.PolitikkRisk)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _politikkRiskRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<PolitikkRisksViewModel> GetAllAsync(Guid politikkId)
        {
            return new PolitikkRisksViewModel()
            {
                PolitikkRisks = await Task.Run(() => _politikkRiskRepository.GetAllAsync(politikkId)).ConfigureAwait(true)
            };
        }

        public async Task<PolitikkRiskViewModel> GetAsync(Guid id)
        {
            return new PolitikkRiskViewModel()
            {
                PolitikkRisk = await Task.Run(() => _politikkRiskRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(PolitikkRiskViewModel model)
        {
            return await Task.Run(() => _politikkRiskRepository.UpdateAsync(model.PolitikkRisk)).ConfigureAwait(true);
        }
    }
}
