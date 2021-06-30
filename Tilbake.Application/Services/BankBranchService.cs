using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class BankBranchService : IBankBranchService
    {
        private readonly IBankBranchRepository _bankBranchRepository;
        
        public BankBranchService(IBankBranchRepository bankBranchRepository)
        {
            _bankBranchRepository = bankBranchRepository ?? throw new ArgumentNullException(nameof(bankBranchRepository));
        }
        
        public async Task<BankBranchResponse> AddAsync(BankBranch bankBranch)
        {
            try
            {
                await _bankBranchRepository.AddAsync(bankBranch).ConfigureAwait(true);
                return new BankBranchResponse(bankBranch);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BankBranchResponse($"An error occurred when saving the bank branch: {ex.Message}");
            }
        }

        public async Task<BankBranchResponse> DeleteAsync(Guid id)
        {
            var existingBankBranch = await _bankBranchRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingBankBranch == null)
                return new BankBranchResponse($"Bank Branch Id not found: {id}");

            try
            {
                await _bankBranchRepository.DeleteAsync(existingBankBranch).ConfigureAwait(false);
                return new BankBranchResponse(existingBankBranch);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BankBranchResponse($"An error occurred when deleting the bank branch: {ex.Message}");
            }
        }

        public async Task<BankBranchResponse> DeleteAsync(BankBranch bankBranch)
        {
            if (bankBranch == null)
                return new BankBranchResponse($"Bank Branch not found: {bankBranch}");

            try
            {
                await _bankBranchRepository.DeleteAsync(bankBranch).ConfigureAwait(false);
                return new BankBranchResponse(bankBranch);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BankBranchResponse($"An error occurred when deleting the bank branch: {ex.Message}");
            }
        }

        public async Task<IEnumerable<BankBranch>> GetAllAsync()
        {
            return await Task.Run(() => _bankBranchRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<BankBranch>> GetByBankId(Guid bankId)
        {
            return await Task.Run(() => _bankBranchRepository.GetByBankId(bankId)).ConfigureAwait(true);
        }

        public async Task<BankBranchResponse> GetByIdAsync(Guid id)
        {
            var bankBranch = await _bankBranchRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (bankBranch == null)
                return new BankBranchResponse($"Bank Branch Id not found: {id}");

            return new BankBranchResponse(bankBranch);
        }

        public async Task<BankBranchResponse> UpdateAsync(Guid id, BankBranch bankBranch)
        {
            if (bankBranch == null)
                return new BankBranchResponse($"Bank Branch not found: {bankBranch}");

            var existingBankBranch = await _bankBranchRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingBankBranch == null)
                return new BankBranchResponse($"Bank Branch Id not found: {id}");

            existingBankBranch.Name = bankBranch.Name;
            existingBankBranch.SortCode = bankBranch.SortCode;
            existingBankBranch.SwiftCode = bankBranch.SwiftCode;

            try
            {
                await _bankBranchRepository.UpdateAsync(existingBankBranch).ConfigureAwait(false);
                return new BankBranchResponse(existingBankBranch);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BankBranchResponse($"An error occurred when updating the bank branch: {ex.Message}");
            }
        }
    }
}