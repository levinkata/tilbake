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
    public class MotorModelService : IMotorModelService
    {
        private readonly IMotorModelRepository _motorModelRepository;

        public MotorModelService(IMotorModelRepository motorModelRepository)
        {
            _motorModelRepository = motorModelRepository;
        }

        public async Task<int> AddAsync(MotorModelViewModel model)
        {
            return await Task.Run(() => _motorModelRepository.AddAsync(model.MotorModel)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _motorModelRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<MotorModelsViewModel> GetAllAsync()
        {
            return new MotorModelsViewModel()
            {
                MotorModels = await Task.Run(() => _motorModelRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<MotorModelViewModel> GetAsync(Guid id)
        {
            return new MotorModelViewModel()
            {
                MotorModel = await Task.Run(() => _motorModelRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<MotorModelsViewModel> GetByMotorMakeAsync(Guid motorMakeId)
        {
            return new MotorModelsViewModel()
            {
                MotorModels = await Task.Run(() => _motorModelRepository.GetByMotorMakeAsync(motorMakeId)).ConfigureAwait(true)
            };
        }
        public async Task<int> UpdateAsync(MotorModelViewModel model)
        {
            return await Task.Run(() => _motorModelRepository.UpdateAsync(model.MotorModel)).ConfigureAwait(true);
        }
    }
}
