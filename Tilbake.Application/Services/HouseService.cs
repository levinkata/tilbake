using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;

        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public async Task<int> AddAsync(HouseViewModel model)
        {
            return await Task.Run(() => _houseRepository.AddAsync(model.KlientID, model.House)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _houseRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<HousesViewModel> GetAllAsync()
        {
            return new HousesViewModel()
            {
                Houses = await _houseRepository.GetAllAsync().ConfigureAwait(true)
            };
        }

        public async Task<HouseViewModel> GetAsync(Guid id)
        {
            return new HouseViewModel()
            {
                House = await _houseRepository.GetAsync(id).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(HouseViewModel model)
        {
            return await Task.Run(() => _houseRepository.UpdateAsync(model.House)).ConfigureAwait(true);
        }
    }
}
