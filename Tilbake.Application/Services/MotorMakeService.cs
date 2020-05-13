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
    public class MotorMakeService : IMotorMakeService
    {
        private readonly IMotorMakeRepository _motorMakeRepository;

        public MotorMakeService(IMotorMakeRepository motorMakeRepository)
        {
            _motorMakeRepository = motorMakeRepository;
        }

        public async Task<int> AddAsync(MotorMakeViewModel model)
        {
            return await Task.Run(() => _motorMakeRepository.AddAsync(model.MotorMake)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _motorMakeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<MotorMakesViewModel> GetAllAsync()
        {
            return new MotorMakesViewModel()
            {
                MotorMakes = await Task.Run(() => _motorMakeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<MotorMakeViewModel> GetAsync(Guid id)
        {
            return new MotorMakeViewModel()
            {
                MotorMake = await Task.Run(() => _motorMakeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(MotorMakeViewModel model)
        {
            return await Task.Run(() => _motorMakeRepository.UpdateAsync(model.MotorMake)).ConfigureAwait(true);
        }
    }
}
