using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class PremiumService : IPremiumService
    {
        private readonly IPremiumRepository _premiumRepository;

        public PremiumService(IPremiumRepository premiumRepository)
        {
            _premiumRepository = premiumRepository;
        }

        public async Task<int> AddAsync(PremiumViewModel model)
        {
            return await Task.Run(() => _premiumRepository.AddAsync(model.Premium)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _premiumRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<PremiumsViewModel> GetAllAsync()
        {
            return new PremiumsViewModel()
            {
                Premiums = await _premiumRepository.GetAllAsync().ConfigureAwait(true)
            };
        }

        public async Task<PremiumViewModel> GetAsync(Guid id)
        {
            return new PremiumViewModel()
            {
                Premium = await _premiumRepository.GetAsync(id).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(PremiumViewModel model)
        {
            return await Task.Run(() => _premiumRepository.UpdateAsync(model.Premium)).ConfigureAwait(true);
        }
    }
}
