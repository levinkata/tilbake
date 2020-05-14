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
    public class PolitikkService : IPolitikkService
    {
        private readonly IPolitikkRepository _politikkRepository;

        public PolitikkService(IPolitikkRepository politikkRepository)
        {
            _politikkRepository = politikkRepository;
        }

        public async Task<int> AddAsync(PolitikkViewModel model)
        {
            return await Task.Run(() => _politikkRepository.AddAsync( model.Politikk)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _politikkRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<PolitikksViewModel> GetAllAsync()
        {
            return new PolitikksViewModel()
            {
                Politikks = await Task.Run(() => _politikkRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<PolitikkViewModel> GetAsync(Guid id)
        {
            return new PolitikkViewModel()
            {
                Politikk = await Task.Run(() => _politikkRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<PolitikksViewModel> GetKlientPolitikkAsync(Guid klientId)
        {
            return new PolitikksViewModel()
            {
                Politikks = await Task.Run(() => _politikkRepository.GetKlientPolitikkAsync(klientId)).ConfigureAwait(true)
            };
        }

        public async Task<PolitikksViewModel> GetPortfolioPolitikkAsync(Guid portfolioId)
        {
            return new PolitikksViewModel()
            {
                Politikks = await Task.Run(() => _politikkRepository.GetPortfolioPolitikkAsync(portfolioId)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(PolitikkViewModel model)
        {
            return await Task.Run(() => _politikkRepository.UpdateAsync(model.Politikk)).ConfigureAwait(true);
        }
    }
}
