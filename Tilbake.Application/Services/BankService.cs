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
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<int> AddAsync(BankViewModel model)
        {
            return await Task.Run(() => _bankRepository.AddAsync(model.Bank)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _bankRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<BanksViewModel> GetAllAsync()
        {
            return new BanksViewModel()
            {
                Banks = await Task.Run(() => _bankRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<BankViewModel> GetAsync(Guid id)
        {
            return new BankViewModel()
            {
                Bank = await Task.Run(() => _bankRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(BankViewModel model)
        {
            return await Task.Run(() => _bankRepository.UpdateAsync(model.Bank)).ConfigureAwait(true);
        }
    }
}
