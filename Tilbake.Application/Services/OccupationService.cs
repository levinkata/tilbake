using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class OccupationService : IOccupationService
    {
        private readonly IOccupationRepository _occupationRepository;
        
        public OccupationService(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository ?? throw new ArgumentNullException(nameof(occupationRepository));
        }

        public async Task<OccupationResponse> AddAsync(Occupation occupation)
        {
            try
            {
                await _occupationRepository.AddAsync(occupation).ConfigureAwait(true);
                return new OccupationResponse(occupation);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OccupationResponse($"An error occurred when saving the occupation: {ex.Message}");
            }
        }

        public async Task<OccupationResponse> DeleteAsync(Guid id)
        {
            var existingOccupation = await _occupationRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingOccupation == null)
                return new OccupationResponse($"Occupation Id not found: {id}");

            try
            {
                await _occupationRepository.DeleteAsync(existingOccupation).ConfigureAwait(false);
                return new OccupationResponse(existingOccupation);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OccupationResponse($"An error occurred when deleting the occupation: {ex.Message}");
            }
        }

        public async Task<OccupationResponse> DeleteAsync(Occupation occupation)
        {
            if (occupation == null)
                return new OccupationResponse($"Occupation not found: {occupation}");

            try
            {
                await _occupationRepository.DeleteAsync(occupation).ConfigureAwait(false);
                return new OccupationResponse(occupation);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OccupationResponse($"An error occurred when deleting the occupation: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Occupation>> GetAllAsync()
        {
            return await Task.Run(() => _occupationRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<OccupationResponse> GetByIdAsync(Guid id)
        {
            var occupation = await _occupationRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (occupation == null)
                return new OccupationResponse($"Occupation Id not found: {id}");

            return new OccupationResponse(occupation);
        }

        public async Task<OccupationResponse> UpdateAsync(Guid id, Occupation occupation)
        {
            if (occupation == null)
                return new OccupationResponse($"Occupation not found: {occupation}");

            var existingOccupation = await _occupationRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingOccupation == null)
                return new OccupationResponse($"Occupation Id not found: {id}");

            existingOccupation.Name = occupation.Name;

            try
            {
                await _occupationRepository.UpdateAsync(existingOccupation).ConfigureAwait(false);
                return new OccupationResponse(existingOccupation);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OccupationResponse($"An error occurred when updating the occupation: {ex.Message}");
            }
        }
    }
}