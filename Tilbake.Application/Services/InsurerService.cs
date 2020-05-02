using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class InsurerService : IInsurerService
    {
        private readonly IInsurerRepository _insurerRepository;

        public InsurerService(IInsurerRepository insurerRepository)
        {
            _insurerRepository = insurerRepository;
        }

        public async Task<int> AddAsync(InsurerViewModel model)
        {
            return await Task.Run(() => _insurerRepository.AddAsync(model.Insurer)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _insurerRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<InsurersViewModel> GetAllAsync()
        {
            return new InsurersViewModel()
            {
                Insurers = await Task.Run(() => _insurerRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<InsurerViewModel> GetAsync(Guid id)
        {
            return new InsurerViewModel()
            {
                Insurer = await Task.Run(() => _insurerRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(InsurerViewModel model)
        {
            return await Task.Run(() => _insurerRepository.UpdateAsync(model.Insurer)).ConfigureAwait(true);
        }
    }
}
