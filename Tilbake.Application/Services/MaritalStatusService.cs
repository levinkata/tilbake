using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IMaritalStatusRepository _maritalStatusRepository;
        
        public MaritalStatusService(IMaritalStatusRepository maritalStatusRepository)
        {
            _maritalStatusRepository = maritalStatusRepository ?? throw new ArgumentNullException(nameof(maritalStatusRepository));
        }

        public async Task<MaritalStatusResponse> AddAsync(MaritalStatus maritalStatus)
        {
            try
            {
                await _maritalStatusRepository.AddAsync(maritalStatus).ConfigureAwait(true);
                return new MaritalStatusResponse(maritalStatus);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MaritalStatusResponse($"An error occurred when saving the maritalStatus: {ex.Message}");
            }
        }

        public async Task<MaritalStatusResponse> DeleteAsync(Guid id)
        {
            var existingMaritalStatus = await _maritalStatusRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingMaritalStatus == null)
                return new MaritalStatusResponse($"MaritalStatus Id not found: {id}");

            try
            {
                await _maritalStatusRepository.DeleteAsync(existingMaritalStatus).ConfigureAwait(false);
                return new MaritalStatusResponse(existingMaritalStatus);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MaritalStatusResponse($"An error occurred when deleting the maritalStatus: {ex.Message}");
            }
        }

        public async Task<MaritalStatusResponse> DeleteAsync(MaritalStatus maritalStatus)
        {
            if (maritalStatus == null)
                return new MaritalStatusResponse($"MaritalStatus not found: {maritalStatus}");

            try
            {
                await _maritalStatusRepository.DeleteAsync(maritalStatus).ConfigureAwait(false);
                return new MaritalStatusResponse(maritalStatus);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MaritalStatusResponse($"An error occurred when deleting the maritalStatus: {ex.Message}");
            }
        }

        public async Task<IEnumerable<MaritalStatus>> GetAllAsync()
        {
            return await Task.Run(() => _maritalStatusRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<MaritalStatusResponse> GetByIdAsync(Guid id)
        {
            var maritalStatus = await _maritalStatusRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (maritalStatus == null)
                return new MaritalStatusResponse($"MaritalStatus Id not found: {id}");

            return new MaritalStatusResponse(maritalStatus);
        }

        public async Task<MaritalStatusResponse> UpdateAsync(Guid id, MaritalStatus maritalStatus)
        {
            if (maritalStatus == null)
                return new MaritalStatusResponse($"MaritalStatus not found: {maritalStatus}");

            var existingMaritalStatus = await _maritalStatusRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingMaritalStatus == null)
                return new MaritalStatusResponse($"MaritalStatus Id not found: {id}");

            existingMaritalStatus.Name = maritalStatus.Name;

            try
            {
                await _maritalStatusRepository.UpdateAsync(existingMaritalStatus).ConfigureAwait(false);
                return new MaritalStatusResponse(existingMaritalStatus);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MaritalStatusResponse($"An error occurred when updating the maritalStatus: {ex.Message}");
            }
        }
    }
}