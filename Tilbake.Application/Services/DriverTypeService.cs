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
    public class DriverTypeService : IDriverTypeService
    {
        private readonly IDriverTypeRepository _driverTypeRepository;

        public DriverTypeService(IDriverTypeRepository driverTypeRepository)
        {
            _driverTypeRepository = driverTypeRepository;
        }

        public async Task<int> AddAsync(DriverTypeViewModel model)
        {
            return await Task.Run(() => _driverTypeRepository.AddAsync(model.DriverType)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _driverTypeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<DriverTypesViewModel> GetAllAsync()
        {
            return new DriverTypesViewModel()
            {
                DriverTypes = await Task.Run(() => _driverTypeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<DriverTypeViewModel> GetAsync(Guid id)
        {
            return new DriverTypeViewModel()
            {
                DriverType = await Task.Run(() => _driverTypeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(DriverTypeViewModel model)
        {
            return await Task.Run(() => _driverTypeRepository.UpdateAsync(model.DriverType)).ConfigureAwait(true);
        }
    }
}
