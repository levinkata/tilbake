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
    public class RiskItemService : IRiskItemService
    {
        private readonly IRiskItemRepository _riskItemRepository;

        public RiskItemService(IRiskItemRepository riskItemRepository)
        {
            _riskItemRepository = riskItemRepository;
        }

        public async Task<int> AddAsync(RiskItemViewModel model)
        {
            return await Task.Run(() => _riskItemRepository.AddAsync(model.RiskItem)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _riskItemRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<RiskItemsViewModel> GetAllAsync()
        {
            return new RiskItemsViewModel()
            {
                RiskItems = await Task.Run(() => _riskItemRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<RiskItemViewModel> GetAsync(Guid id)
        {
            return new RiskItemViewModel()
            {
                RiskItem = await Task.Run(() => _riskItemRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(RiskItemViewModel model)
        {
            return await Task.Run(() => _riskItemRepository.UpdateAsync(model.RiskItem)).ConfigureAwait(true);
        }
    }
}
