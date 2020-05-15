using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class GlassService : IGlassService
    {
        private readonly IGlassRepository _glassRepository;

        public GlassService(IGlassRepository glassRepository)
        {
            _glassRepository = glassRepository;
        }

        public async Task<int> AddAsync(GlassViewModel model)
        {
            return await Task.Run(() => _glassRepository.AddAsync(model.KlientID, model.Glass)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _glassRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<GlassesViewModel> GetAllAsync()
        {
            return new GlassesViewModel()
            {
                Glasses = await _glassRepository.GetAllAsync().ConfigureAwait(true)
            };
        }

        public async Task<GlassViewModel> GetAsync(Guid id)
        {
            return new GlassViewModel()
            {
                Glass = await _glassRepository.GetAsync(id).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(GlassViewModel model)
        {
            return await Task.Run(() => _glassRepository.UpdateAsync(model.Glass)).ConfigureAwait(true);
        }
    }
}
