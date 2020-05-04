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
    public class KlientService : IKlientService
    {
        private readonly IKlientRepository _klientRepository;

        public KlientService(IKlientRepository klientRepository)
        {
            _klientRepository = klientRepository;
        }

        public async Task<int> AddAsync(KlientViewModel model)
        {
            return await Task.Run(() => _klientRepository.AddAsync(model.PortfolioID, model.Klient)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _klientRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<KlientsViewModel> GetAllAsync()
        {
            return new KlientsViewModel()
            {
                Klients = await Task.Run(() => _klientRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<KlientViewModel> GetAsync(Guid id)
        {
            return new KlientViewModel()
            {
                Klient = await Task.Run(() => _klientRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<KlientViewModel> GetByIdNumberAsync(string idNumber)
        {
            return new KlientViewModel()
            {
                Klient = await Task.Run(() => _klientRepository.GetByIdNumberAsync(idNumber)).ConfigureAwait(true)
            };
        }

        public async Task<KlientViewModel> GetByKlientNumberAsync(int klientNumber)
        {
            return new KlientViewModel()
            {
                Klient = await Task.Run(() => _klientRepository.GetByKlientNumberAsync(klientNumber)).ConfigureAwait(true)
            };
        }

        public async Task<KlientsViewModel> GetByNameAsync(string klientName)
        {
            return new KlientsViewModel()
            {
                Klients = await Task.Run(() => _klientRepository.GetByNameAsync(klientName)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(KlientViewModel model)
        {
            return await Task.Run(() => _klientRepository.UpdateAsync(model.Klient)).ConfigureAwait(true);
        }
    }
}
