using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Services
{
    public class KlientService : IKlientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KlientService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<KlientResponse> AddAsync(Klient klient)
        {
            try
            {
                await _unitOfWork.Klient.AddAsync(klient).ConfigureAwait(true);
                await _unitOfWork.CompleteAsync().ConfigureAwait(true);

                return new KlientResponse(klient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new KlientResponse($"An error occurred when saving the klient: {ex.Message}");
            }
        }

        public async Task<KlientResponse> AddToPortfolio(Guid portfolioId, Klient klient)
        {
            try
            {
                await _unitOfWork.Klient.AddToPortfolio(portfolioId, klient).ConfigureAwait(true);
                await _unitOfWork.CompleteAsync().ConfigureAwait(true);

                return new KlientResponse(klient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new KlientResponse($"An error occurred when saving the klient: {ex.Message}");
            }
        }

        public async Task<KlientResponse> DeleteAsync(Guid id)
        {
            var existingKlient = await _unitOfWork.Klient.GetById(id).ConfigureAwait(true);

            if (existingKlient == null)
                return new KlientResponse($"Klient not found. {id}");

            try
            {
                _unitOfWork.Klient.Delete(existingKlient);
                await _unitOfWork.CompleteAsync().ConfigureAwait(true);

                return new KlientResponse(existingKlient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new KlientResponse($"An error occurred when deleting the klient: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Klient>> GetAllAsync()
        {
            return await Task.Run(() => _unitOfWork.Klient.GetAll()).ConfigureAwait(true);
        }

        public async Task<KlientResponse> GetAsync(Guid id)
        {
            var klient = await Task.Run(() => _unitOfWork.Klient.GetById(id)).ConfigureAwait(true);
            if (klient == null)
                return new KlientResponse($"Klient not found: {id}");

            return new KlientResponse(klient);
        }

        public async Task<KlientResponse> GetByIdNumberAsync(string idNumber)
        {
            var klient = await Task.Run(() => _unitOfWork.Klient.GetByIdNumberAsync(idNumber)).ConfigureAwait(true);
            if (klient == null)
                return new KlientResponse($"Klient not found: {idNumber}");

            return new KlientResponse(klient);
        }

        public async Task<KlientResponse> GetByKlientNumberAsync(int klientNumber)
        {
            var klient = await Task.Run(() => _unitOfWork.Klient.GetByKlientNumberAsync(klientNumber)).ConfigureAwait(true);
            if (klient == null)
                return new KlientResponse($"Klient not found: {klientNumber}");

            return new KlientResponse(klient);
        }

        public async Task<IEnumerable<Klient>> GetByNameAsync(string klientName)
        {
            return await Task.Run(() => _unitOfWork.Klient.GetByNameAsync(klientName)).ConfigureAwait(true);
        }

        public async Task<KlientResponse> UpdateAsync(Guid id, Klient klient)
        {
            if (klient == null)
            {
                throw new ArgumentNullException(nameof(klient));
            }

            var existingKlient = await _unitOfWork.Klient.GetById(id).ConfigureAwait(true);

            if (existingKlient == null)
                return new KlientResponse($"Klient not found. {id}");

            existingKlient.TitleId = klient.TitleId;
            existingKlient.KlientNumber = klient.KlientNumber;
            existingKlient.KlientType = klient.KlientType;
            existingKlient.FirstName = klient.FirstName;
            existingKlient.LastName = klient.LastName;
            existingKlient.BirthDate = klient.BirthDate;
            existingKlient.Gender = klient.Gender;
            existingKlient.IdNumber = klient.IdNumber;
            existingKlient.Phone = klient.Phone;
            existingKlient.Mobile = klient.Mobile;
            existingKlient.Email = klient.Email;
            existingKlient.Carrier = klient.Carrier;
            existingKlient.OccupationId = klient.OccupationId;
            existingKlient.LandId = klient.LandId;

            try
            {
                _unitOfWork.Klient.Update(existingKlient);
                await _unitOfWork.CompleteAsync().ConfigureAwait(true);

                return new KlientResponse(existingKlient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new KlientResponse($"An error occurred when updating the klient: {ex.Message}");
            }
        }
    }
}
