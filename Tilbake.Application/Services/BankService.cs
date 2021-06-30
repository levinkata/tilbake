using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        
        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository ?? throw new ArgumentNullException(nameof(bankRepository));
        }

        public async Task<BankResponse> AddAsync(Bank bank)
        {
            try
            {
                await _bankRepository.AddAsync(bank).ConfigureAwait(true);
                return new BankResponse(bank);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BankResponse($"An error occurred when saving the bank: {ex.Message}");
            }
        }

        public async Task<BankResponse> DeleteAsync(Guid id)
        {
            var existingBank = await _bankRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingBank == null)
                return new BankResponse($"Bank Id not found: {id}");

            try
            {
                await _bankRepository.DeleteAsync(existingBank).ConfigureAwait(false);
                return new BankResponse(existingBank);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BankResponse($"An error occurred when deleting the bank: {ex.Message}");
            }
        }

        public async Task<BankResponse> DeleteAsync(Bank bank)
        {
            if (bank == null)
                return new BankResponse($"Bank not found: {bank}");

            try
            {
                await _bankRepository.DeleteAsync(bank).ConfigureAwait(false);
                return new BankResponse(bank);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BankResponse($"An error occurred when deleting the bank: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Bank>> GetAllAsync()
        {
            return await Task.Run(() => _bankRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<BankResponse> GetByIdAsync(Guid id)
        {
            var bank = await _bankRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (bank == null)
                return new BankResponse($"Bank Id not found: {id}");

            return new BankResponse(bank);
        }

        public async Task<BankResponse> UpdateAsync(Guid id, Bank bank)
        {
            if (bank == null)
                return new BankResponse($"Bank not found: {bank}");

            var existingBank = await _bankRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingBank == null)
                return new BankResponse($"Bank Id not found: {id}");

            existingBank.Name = bank.Name;

            try
            {
                await _bankRepository.UpdateAsync(existingBank).ConfigureAwait(false);
                return new BankResponse(existingBank);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BankResponse($"An error occurred when updating the bank: {ex.Message}");
            }
        }
    }
}