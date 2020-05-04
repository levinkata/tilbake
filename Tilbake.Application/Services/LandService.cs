using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class LandService : ILandService
    {
        private readonly ILandRepository _landRepository;

        public LandService(ILandRepository landRepository)
        {
            _landRepository = landRepository;
        }

        public async Task<int> AddAsync(LandViewModel model)
        {
            return await Task.Run(() => _landRepository.AddAsync(model.Land)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _landRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<LandsViewModel> GetAllAsync()
        {
            return new LandsViewModel()
            {
                Lands = await Task.Run(() => _landRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<LandViewModel> GetAsync(Guid id)
        {
            return new LandViewModel()
            {
                Land = await Task.Run(() => _landRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(LandViewModel model)
        {
            return await Task.Run(() => _landRepository.UpdateAsync(model.Land)).ConfigureAwait(true);
        }
    }
}
