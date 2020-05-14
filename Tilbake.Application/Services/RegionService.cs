using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }
        
        public async Task<int> AddAsync(RegionViewModel model)
        {
            return await Task.Run(() => _regionRepository.AddAsync(model.Region)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _regionRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<RegionsViewModel> GetAllAsync()
        {
            return new RegionsViewModel()
            {
                Regions = await Task.Run(() => _regionRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<RegionViewModel> GetAsync(Guid id)
        {
            return new RegionViewModel()
            {
                Region = await Task.Run(() => _regionRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(RegionViewModel model)
        {
            return await Task.Run(() => _regionRepository.UpdateAsync(model.Region)).ConfigureAwait(true);
        }
    }
}