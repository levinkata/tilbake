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
    public class PremiumTypeService : IPremiumTypeService
    {
        private readonly IPremiumTypeRepository _premiumTypeRepository;

        public PremiumTypeService(IPremiumTypeRepository premiumTypeRepository)
        {
            _premiumTypeRepository = premiumTypeRepository;
        }

        public async Task<int> AddAsync(PremiumTypeViewModel model)
        {
            return await Task.Run(() => _premiumTypeRepository.AddAsync(model.PremiumType)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _premiumTypeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<PremiumTypesViewModel> GetAllAsync()
        {
            return new PremiumTypesViewModel()
            {
                PremiumTypes = await Task.Run(() => _premiumTypeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<PremiumTypeViewModel> GetAsync(Guid id)
        {
            return new PremiumTypeViewModel()
            {
                PremiumType = await Task.Run(() => _premiumTypeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(PremiumTypeViewModel model)
        {
            return await Task.Run(() => _premiumTypeRepository.UpdateAsync(model.PremiumType)).ConfigureAwait(true);
        }
    }
}
