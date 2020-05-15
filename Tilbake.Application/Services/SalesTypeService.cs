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
    public class SalesTypeService : ISalesTypeService
    {
        private readonly ISalesTypeRepository _salesTypeRepository;

        public SalesTypeService(ISalesTypeRepository salesTypeRepository)
        {
            _salesTypeRepository = salesTypeRepository;
        }

        public async Task<int> AddAsync(SalesTypeViewModel model)
        {
            return await Task.Run(() => _salesTypeRepository.AddAsync(model.SalesType)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _salesTypeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<SalesTypesViewModel> GetAllAsync()
        {
            return new SalesTypesViewModel()
            {
                SalesTypes = await Task.Run(() => _salesTypeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<SalesTypeViewModel> GetAsync(Guid id)
        {
            return new SalesTypeViewModel()
            {
                SalesType = await Task.Run(() => _salesTypeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(SalesTypeViewModel model)
        {
            return await Task.Run(() => _salesTypeRepository.UpdateAsync(model.SalesType)).ConfigureAwait(true);
        }
    }
}
