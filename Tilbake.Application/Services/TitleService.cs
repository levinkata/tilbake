using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Services
{
    public class TitleService : ITitleService
    {
        //private readonly ITitleRepository _titleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TitleService(IUnitOfWork unitOfWork)
        {
            //_titleRepository = titleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TitleResponse> SaveAsync(Title title)
        {
            try
            {
                //await _titleRepository.AddAsync(title).ConfigureAwait(true);
                await _unitOfWork.Title.AddAsync(title).ConfigureAwait(true);
                await _unitOfWork.CompleteAsync().ConfigureAwait(true);

                return new TitleResponse(title);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TitleResponse($"An error occurred when saving the title: {ex.Message}");
            }
        }

        public async Task<TitleResponse> DeleteAsync(Guid id)
        {
            //var existingTitle = await _titleRepository.GetById(id).ConfigureAwait(true);
            var existingTitle = await _unitOfWork.Title.GetById(id).ConfigureAwait(true);

            if (existingTitle == null)
                return new TitleResponse($"Category not found: {id}");

            try
            {
                _unitOfWork.Title.Delete(existingTitle);
                await _unitOfWork.CompleteAsync().ConfigureAwait(true);

                return new TitleResponse(existingTitle);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TitleResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Title>> GetAllAsync()
        {
            return await Task.Run(() => _unitOfWork.Title.GetAll()).ConfigureAwait(true);
        }

        public async Task<TitleResponse> GetAsync(Guid id)
        {
            var title = await _unitOfWork.Title.GetById(id).ConfigureAwait(true);
            if (title == null)
                return new TitleResponse($"Title not found: {id}");

            return new TitleResponse(title);
        }

        public async Task<TitleResponse> UpdateAsync(Guid id, Title title)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            var existingTitle = await _unitOfWork.Title.GetById(id).ConfigureAwait(true);

            if (existingTitle == null)
                return new TitleResponse($"Title with ID {id} not found.");

            existingTitle.Name = title.Name;

            try
            {
                await _unitOfWork.CompleteAsync().ConfigureAwait(true);

                return new TitleResponse(existingTitle);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TitleResponse($"An error occurred when updating the title: {ex.Message}");
            }
        }        
    }
}