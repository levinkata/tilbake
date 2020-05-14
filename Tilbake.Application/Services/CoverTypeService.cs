using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class CoverTypeService : ICoverTypeService
    {
        private readonly ICoverTypeRepository _coverTypeRepository;

        public CoverTypeService(ICoverTypeRepository coverTypeRepository)
        {
            _coverTypeRepository = coverTypeRepository;
        }

        public async Task<int> AddAsync(CoverTypeViewModel model)
        {
            return await Task.Run(() => _coverTypeRepository.AddAsync(model.CoverType)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _coverTypeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<CoverTypesViewModel> GetAllAsync()
        {
            return new CoverTypesViewModel()
            {
                CoverTypes = await Task.Run(() => _coverTypeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<CoverTypeViewModel> GetAsync(Guid id)
        {
            return new CoverTypeViewModel()
            {
                CoverType = await Task.Run(() => _coverTypeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(CoverTypeViewModel model)
        {
            return await Task.Run(() => _coverTypeRepository.UpdateAsync(model.CoverType)).ConfigureAwait(true);
        }
    }
}
