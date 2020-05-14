using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class RoofTypeService : IRoofTypeService
    {
        private readonly IRoofTypeRepository _roofTypeRepository;

        public RoofTypeService(IRoofTypeRepository roofTypeRepository)
        {
            _roofTypeRepository = roofTypeRepository;
        }
        
        public async Task<int> AddAsync(RoofTypeViewModel model)
        {
            return await Task.Run(() => _roofTypeRepository.AddAsync(model.RoofType)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _roofTypeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<RoofTypesViewModel> GetAllAsync()
        {
            return new RoofTypesViewModel()
            {
                RoofTypes = await Task.Run(() => _roofTypeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<RoofTypeViewModel> GetAsync(Guid id)
        {
            return new RoofTypeViewModel()
            {
                RoofType = await Task.Run(() => _roofTypeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(RoofTypeViewModel model)
        {
            return await Task.Run(() => _roofTypeRepository.UpdateAsync(model.RoofType)).ConfigureAwait(true);
        }
    }
}