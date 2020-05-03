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
    public class BankBranchService : IBankBranchService
    {
        private readonly IBankBranchRepository _bankBranchRepository;

        public BankBranchService(IBankBranchRepository bankBranchRepository)
        {
            _bankBranchRepository = bankBranchRepository;
        }

        public async Task<int> AddAsync(BankBranchViewModel model)
        {
            return await Task.Run(() => _bankBranchRepository.AddAsync(model.BankBranch)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _bankBranchRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<BankBranchesViewModel> GetAllAsync(Guid bankId)
        {
            return new BankBranchesViewModel()
            {
                BankBranches = await Task.Run(() => _bankBranchRepository.GetAllAsync(bankId)).ConfigureAwait(true)
            };
        }

        public async Task<BankBranchViewModel> GetAsync(Guid id)
        {
            return new BankBranchViewModel()
            {
                BankBranch = await Task.Run(() => _bankBranchRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(BankBranchViewModel model)
        {
            return await Task.Run(() => _bankBranchRepository.UpdateAsync(model.BankBranch)).ConfigureAwait(true);
        }
    }
}
