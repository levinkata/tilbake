using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class WallTypeService : IWallTypeService
    {
        private readonly IWallTypeRepository _wallTypeRepository;

        public WallTypeService(IWallTypeRepository wallTypeRepository)
        {
            _wallTypeRepository = wallTypeRepository;
        }
        
        public async Task<int> AddAsync(WallTypeViewModel model)
        {
            return await Task.Run(() => _wallTypeRepository.AddAsync(model.WallType)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _wallTypeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<WallTypesViewModel> GetAllAsync()
        {
            return new WallTypesViewModel()
            {
                WallTypes = await Task.Run(() => _wallTypeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<WallTypeViewModel> GetAsync(Guid id)
        {
            return new WallTypeViewModel()
            {
                WallType = await Task.Run(() => _wallTypeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(WallTypeViewModel model)
        {
            return await Task.Run(() => _wallTypeRepository.UpdateAsync(model.WallType)).ConfigureAwait(true);
        }
    }
}