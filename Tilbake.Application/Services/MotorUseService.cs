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
    public class MotorUseService : IMotorUseService
    {
        private readonly IMotorUseRepository _motorUseRepository;

        public MotorUseService(IMotorUseRepository motorUseRepository)
        {
            _motorUseRepository = motorUseRepository;
        }

        public async Task<int> AddAsync(MotorUseViewModel model)
        {
            return await Task.Run(() => _motorUseRepository.AddAsync(model.MotorUse)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _motorUseRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<MotorUsesViewModel> GetAllAsync()
        {
            return new MotorUsesViewModel()
            {
                MotorUses = await Task.Run(() => _motorUseRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<MotorUseViewModel> GetAsync(Guid id)
        {
            return new MotorUseViewModel()
            {
                MotorUse = await Task.Run(() => _motorUseRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(MotorUseViewModel model)
        {
            return await Task.Run(() => _motorUseRepository.UpdateAsync(model.MotorUse)).ConfigureAwait(true);
        }
    }
}
