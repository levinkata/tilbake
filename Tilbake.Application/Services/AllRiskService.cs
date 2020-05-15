using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class AllRiskService : IAllRiskService
    {
        private readonly IAllRiskRepository _allRiskRepository;

        public AllRiskService(IAllRiskRepository allRiskRepository)
        {
            _allRiskRepository = allRiskRepository;
        }

        public async Task<int> AddAsync(AllRiskViewModel model)
        {
            return await Task.Run(() => _allRiskRepository.AddAsync(model.KlientID, model.AllRisk)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _allRiskRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<AllRisksViewModel> GetAllAsync()
        {
            return new AllRisksViewModel()
            {
                AllRisks = await _allRiskRepository.GetAllAsync().ConfigureAwait(true)
            };
        }

        public async Task<AllRiskViewModel> GetAsync(Guid id)
        {
            return new AllRiskViewModel()
            {
                AllRisk = await _allRiskRepository.GetAsync(id).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(AllRiskViewModel model)
        {
            return await Task.Run(() => _allRiskRepository.UpdateAsync(model.AllRisk)).ConfigureAwait(true);
        }
    }
}
