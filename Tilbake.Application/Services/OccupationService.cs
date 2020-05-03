using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class OccupationService : IOccupationService
    {
        private readonly IOccupationRepository _occupationRepository;

        public OccupationService(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        public async Task<int> AddAsync(OccupationViewModel model)
        {
            return await Task.Run(() => _occupationRepository.AddAsync(model.Occupation)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _occupationRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<OccupationsViewModel> GetAllAsync()
        {
            return new OccupationsViewModel()
            {
                Occupations = await Task.Run(() => _occupationRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<OccupationViewModel> GetAsync(Guid id)
        {
            return new OccupationViewModel()
            {
                Occupation = await Task.Run(() => _occupationRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(OccupationViewModel model)
        {
            return await Task.Run(() => _occupationRepository.UpdateAsync(model.Occupation)).ConfigureAwait(true);
        }
    }
}
