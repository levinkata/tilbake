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
    public class KravService : IKravService
    {
        private readonly IKravRepository _kravRepository;

        public KravService(IKravRepository kravRepository)
        {
            _kravRepository = kravRepository;
        }

        public async Task<int> AddAsync(KravViewModel model)
        {
            return await Task.Run(() => _kravRepository.AddAsync(model.Krav)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await Task.Run(() => _kravRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<KravsViewModel> GetAllAsync()
        {
            return new KravsViewModel()
            {
                Kravs = await Task.Run(() => _kravRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<KravViewModel> GetAsync(int id)
        {
            return new KravViewModel()
            {
                Krav = await Task.Run(() => _kravRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<KravsViewModel> GetByPolitikkRiskAsync(Guid politikRiskId)
        {
            return new KravsViewModel()
            {
                Kravs = await Task.Run(() => _kravRepository.GetByPolitikkRiskAsync(politikRiskId)).ConfigureAwait(true)
            };
        }

        public async Task<KravsViewModel> GetByPortfolioKlientAsync(Guid portfolioKlientId)
        {
            return new KravsViewModel()
            {
                Kravs = await Task.Run(() => _kravRepository.GetByPortfolioKlientAsync(portfolioKlientId)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(KravViewModel model)
        {
            return await Task.Run(() => _kravRepository.UpdateAsync(model.Krav)).ConfigureAwait(true);
        }
    }
}
