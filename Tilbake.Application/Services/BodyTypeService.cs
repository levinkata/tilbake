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
    public class BodyTypeService : IBodyTypeService
    {
        private readonly IBodyTypeRepository _bodyTypeRepository;

        public BodyTypeService(IBodyTypeRepository bodyTypeRepository)
        {
            _bodyTypeRepository = bodyTypeRepository;
        }

        public async Task<int> AddAsync(BodyTypeViewModel model)
        {
            return await Task.Run(() => _bodyTypeRepository.AddAsync(model.BodyType)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _bodyTypeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<BodyTypesViewModel> GetAllAsync()
        {
            return new BodyTypesViewModel()
            {
                BodyTypes = await Task.Run(() => _bodyTypeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<BodyTypeViewModel> GetAsync(Guid id)
        {
            return new BodyTypeViewModel()
            {
                BodyType = await Task.Run(() => _bodyTypeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(BodyTypeViewModel model)
        {
            return await Task.Run(() => _bodyTypeRepository.UpdateAsync(model.BodyType)).ConfigureAwait(true);
        }
    }
}
