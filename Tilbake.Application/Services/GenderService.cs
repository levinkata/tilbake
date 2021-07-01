using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        
        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository ?? throw new ArgumentNullException(nameof(genderRepository));
        }

        public async Task<GenderResponse> AddAsync(Gender gender)
        {
            try
            {
                await _genderRepository.AddAsync(gender).ConfigureAwait(true);
                return new GenderResponse(gender);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new GenderResponse($"An error occurred when saving the gender: {ex.Message}");
            }
        }

        public async Task<GenderResponse> DeleteAsync(Guid id)
        {
            var existingGender = await _genderRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingGender == null)
                return new GenderResponse($"Gender Id not found: {id}");

            try
            {
                await _genderRepository.DeleteAsync(existingGender).ConfigureAwait(false);
                return new GenderResponse(existingGender);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new GenderResponse($"An error occurred when deleting the gender: {ex.Message}");
            }
        }

        public async Task<GenderResponse> DeleteAsync(Gender gender)
        {
            if (gender == null)
                return new GenderResponse($"Gender not found: {gender}");

            try
            {
                await _genderRepository.DeleteAsync(gender).ConfigureAwait(false);
                return new GenderResponse(gender);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new GenderResponse($"An error occurred when deleting the gender: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Gender>> GetAllAsync()
        {
            return await Task.Run(() => _genderRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<GenderResponse> GetByIdAsync(Guid id)
        {
            var gender = await _genderRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (gender == null)
                return new GenderResponse($"Gender Id not found: {id}");

            return new GenderResponse(gender);
        }

        public async Task<GenderResponse> UpdateAsync(Guid id, Gender gender)
        {
            if (gender == null)
                return new GenderResponse($"Gender not found: {gender}");

            var existingGender = await _genderRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingGender == null)
                return new GenderResponse($"Gender Id not found: {id}");

            existingGender.Name = gender.Name;

            try
            {
                await _genderRepository.UpdateAsync(existingGender).ConfigureAwait(false);
                return new GenderResponse(existingGender);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new GenderResponse($"An error occurred when updating the gender: {ex.Message}");
            }
        }
    }
}