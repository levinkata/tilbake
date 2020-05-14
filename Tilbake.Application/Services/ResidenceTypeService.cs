using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class ResidenceTypeService : IResidenceTypeService
    {
        private readonly IResidenceTypeRepository _residenceTypeRepository;

        public ResidenceTypeService(IResidenceTypeRepository residenceTypeRepository)
        {
            _residenceTypeRepository = residenceTypeRepository;
        }
        
        public async Task<int> AddAsync(ResidenceTypeViewModel model)
        {
            return await Task.Run(() => _residenceTypeRepository.AddAsync(model.ResidenceType)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _residenceTypeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<ResidenceTypesViewModel> GetAllAsync()
        {
            return new ResidenceTypesViewModel()
            {
                ResidenceTypes = await Task.Run(() => _residenceTypeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<ResidenceTypeViewModel> GetAsync(Guid id)
        {
            return new ResidenceTypeViewModel()
            {
                ResidenceType = await Task.Run(() => _residenceTypeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(ResidenceTypeViewModel model)
        {
            return await Task.Run(() => _residenceTypeRepository.UpdateAsync(model.ResidenceType)).ConfigureAwait(true);
        }
    }
}