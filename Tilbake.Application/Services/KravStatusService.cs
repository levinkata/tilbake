using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class KravStatusService : IKravStatusService
    {
        private readonly IKravStatusRepository _kravStatusRepository;

        public KravStatusService(IKravStatusRepository kravStatusRepository)
        {
            _kravStatusRepository = kravStatusRepository;
        }

        public async Task<int> AddAsync(KravStatusViewModel model)
        {
            return await Task.Run(() => _kravStatusRepository.AddAsync(model.KravStatus)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _kravStatusRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<KravStatusesViewModel> GetAllAsync()
        {
            return new KravStatusesViewModel()
            {
                KravStatuses = await Task.Run(() => _kravStatusRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<KravStatusViewModel> GetAsync(Guid id)
        {
            return new KravStatusViewModel()
            {
                KravStatus = await Task.Run(() => _kravStatusRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(KravStatusViewModel model)
        {
            return await Task.Run(() => _kravStatusRepository.UpdateAsync(model.KravStatus)).ConfigureAwait(true);
        }
    }
}
