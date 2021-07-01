using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class CarrierService : ICarrierService
    {
        private readonly ICarrierRepository _carrierRepository;
        
        public CarrierService(ICarrierRepository carrierRepository)
        {
            _carrierRepository = carrierRepository ?? throw new ArgumentNullException(nameof(carrierRepository));
        }

        public async Task<CarrierResponse> AddAsync(Carrier carrier)
        {
            try
            {
                await _carrierRepository.AddAsync(carrier).ConfigureAwait(true);
                return new CarrierResponse(carrier);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CarrierResponse($"An error occurred when saving the carrier: {ex.Message}");
            }
        }

        public async Task<CarrierResponse> DeleteAsync(Guid id)
        {
            var existingCarrier = await _carrierRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingCarrier == null)
                return new CarrierResponse($"Carrier Id not found: {id}");

            try
            {
                await _carrierRepository.DeleteAsync(existingCarrier).ConfigureAwait(false);
                return new CarrierResponse(existingCarrier);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CarrierResponse($"An error occurred when deleting the carrier: {ex.Message}");
            }
        }

        public async Task<CarrierResponse> DeleteAsync(Carrier carrier)
        {
            if (carrier == null)
                return new CarrierResponse($"Carrier not found: {carrier}");

            try
            {
                await _carrierRepository.DeleteAsync(carrier).ConfigureAwait(false);
                return new CarrierResponse(carrier);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CarrierResponse($"An error occurred when deleting the carrier: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Carrier>> GetAllAsync()
        {
            return await Task.Run(() => _carrierRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<CarrierResponse> GetByIdAsync(Guid id)
        {
            var carrier = await _carrierRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (carrier == null)
                return new CarrierResponse($"Carrier Id not found: {id}");

            return new CarrierResponse(carrier);
        }

        public async Task<CarrierResponse> UpdateAsync(Guid id, Carrier carrier)
        {
            if (carrier == null)
                return new CarrierResponse($"Carrier not found: {carrier}");

            var existingCarrier = await _carrierRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingCarrier == null)
                return new CarrierResponse($"Carrier Id not found: {id}");

            existingCarrier.Name = carrier.Name;

            try
            {
                await _carrierRepository.UpdateAsync(existingCarrier).ConfigureAwait(false);
                return new CarrierResponse(existingCarrier);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CarrierResponse($"An error occurred when updating the carrier: {ex.Message}");
            }
        }
    }
}