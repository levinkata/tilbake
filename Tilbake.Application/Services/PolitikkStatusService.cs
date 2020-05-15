using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class PolitikkStatusService : IPolitikkStatusService
    {
        private readonly IPolitikkStatusRepository _politikkStatusRepository;

        public PolitikkStatusService(IPolitikkStatusRepository politikkStatusRepository)
        {
            _politikkStatusRepository = politikkStatusRepository;
        }

        public async Task<int> AddAsync(PolitikkStatusViewModel model)
        {
            return await Task.Run(() => _politikkStatusRepository.AddAsync(model.PolitikkStatus)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _politikkStatusRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<PolitikkStatusesViewModel> GetAllAsync()
        {
            return new PolitikkStatusesViewModel()
            {
                PolitikkStatuses = await Task.Run(() => _politikkStatusRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<PolitikkStatusViewModel> GetAsync(Guid id)
        {
            return new PolitikkStatusViewModel()
            {
                PolitikkStatus = await Task.Run(() => _politikkStatusRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(PolitikkStatusViewModel model)
        {
            return await Task.Run(() => _politikkStatusRepository.UpdateAsync(model.PolitikkStatus)).ConfigureAwait(true);
        }
    }
}
