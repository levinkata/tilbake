using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TitleService(ITitleRepository titleRepository, IUnitOfWork unitOfWork)
        {
            _titleRepository = titleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TitleResponse> SaveAsync(Title title)
        {
            // return await Task.Run(() => _titleRepository.AddAsync(model.Title)).ConfigureAwait(true);
            try
            {
                await _titleRepository.AddAsync(title).ConfigureAwait(true);
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
            // return await Task.Run(() => _titleRepository.DeleteAsync(id)).ConfigureAwait(true);
            var existingTitle = await _titleRepository.GetAsync(id).ConfigureAwait(true);

            if (existingTitle == null)
                return new TitleResponse($"Category not found: {id}");

            try
            {
                _titleRepository.DeleteAsync(existingTitle);
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
            //return new TitlesViewModel()
            //{
            //    Titles = await Task.Run(() => _titleRepository.GetAllAsync()).ConfigureAwait(true)
            //};
            return await Task.Run(() => _titleRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<TitleViewModel> GetAsync(Guid id)
        {
            return new TitleViewModel()
            {
                Title = await Task.Run(() => _titleRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<TitleResponse> UpdateAsync(Guid id, Title title)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            // return await Task.Run(() => _titleRepository.UpdateAsync(model.Title)).ConfigureAwait(true);
            var existingTitle = await _titleRepository.GetAsync(id).ConfigureAwait(true);

            if (existingTitle == null)
                return new TitleResponse($"Title not found: {id}");

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