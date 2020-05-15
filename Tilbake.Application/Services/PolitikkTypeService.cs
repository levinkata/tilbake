using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class PolitikkTypeService : IPolitikkTypeService
    {
        private readonly IPolitikkTypeRepository _politikkTypeRepository;

        public PolitikkTypeService(IPolitikkTypeRepository politikkTypeRepository)
        {
            _politikkTypeRepository = politikkTypeRepository;
        }

        public async Task<int> AddAsync(PolitikkTypeViewModel model)
        {
            return await Task.Run(() => _politikkTypeRepository.AddAsync(model.PolitikkType)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _politikkTypeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<PolitikkTypesViewModel> GetAllAsync()
        {
            return new PolitikkTypesViewModel()
            {
                PolitikkTypes = await Task.Run(() => _politikkTypeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<PolitikkTypeViewModel> GetAsync(Guid id)
        {
            return new PolitikkTypeViewModel()
            {
                PolitikkType = await Task.Run(() => _politikkTypeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(PolitikkTypeViewModel model)
        {
            return await Task.Run(() => _politikkTypeRepository.UpdateAsync(model.PolitikkType)).ConfigureAwait(true);
        }
    }
}
