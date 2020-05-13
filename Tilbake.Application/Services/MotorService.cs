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
    public class MotorService : IMotorService
    {
        private readonly IMotorRepository _motorRepository;

        public MotorService(IMotorRepository motorRepository)
        {
            _motorRepository = motorRepository;
        }

        public async Task<int> AddAsync(MotorViewModel model)
        {
            return await Task.Run(() => _motorRepository.AddAsync(model.KlientID, model.Motor)).ConfigureAwait(true);
        }

        public async Task<bool> ChassissNumberExists(Guid id, string chassissNumber)
        {
            return await Task.Run(() => _motorRepository.ChassissNumberExists(id, chassissNumber)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _motorRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<bool> EngineNumberExists(Guid id, string engineNumber)
        {
            return await Task.Run(() => _motorRepository.EngineNumberExists(id, engineNumber)).ConfigureAwait(true);
        }

        public async Task<MotorsViewModel> GetAllAsync()
        {
            return new MotorsViewModel()
            {
                Motors = await _motorRepository.GetAllAsync().ConfigureAwait(true)
            };
        }

        public async Task<MotorViewModel> GetByChassissNumberAsync(string chassissNumber)
        {
            return new MotorViewModel()
            {
                Motor = await _motorRepository.GetByChassissNumberAsync(chassissNumber).ConfigureAwait(true)
            };
        }

        public async Task<MotorViewModel> GetByEngineNumberAsync(string engineNumber)
        {
            return new MotorViewModel()
            {
                Motor = await _motorRepository.GetByEngineNumberAsync(engineNumber).ConfigureAwait(true)
            };
        }

        public async Task<MotorViewModel> GetByRegNumberAsync(string regNumber)
        {
            return new MotorViewModel()
            {
                Motor = await _motorRepository.GetByRegNumberAsync(regNumber).ConfigureAwait(true)
            };
        }

        public async Task<MotorViewModel> GetMotorAsync(Guid id)
        {
            return new MotorViewModel()
            {
                Motor = await _motorRepository.GetMotorAsync(id).ConfigureAwait(true)
            };
        }

        public async Task<bool> RegNumberExists(Guid id, string regNumber)
        {
            return await Task.Run(() => _motorRepository.RegNumberExists(id, regNumber)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(MotorViewModel model)
        {
            return await Task.Run(() => _motorRepository.UpdateAsync(model.Motor)).ConfigureAwait(true);
        }
    }
}
