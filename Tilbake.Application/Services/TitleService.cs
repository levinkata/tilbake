using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;
        
        public TitleService(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository ?? throw new ArgumentNullException(nameof(titleRepository));
        }

        public async Task<TitleResponse> AddAsync(Title title)
        {
            try
            {
                await _titleRepository.AddAsync(title).ConfigureAwait(true);
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
            var existingTitle = await _titleRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingTitle == null)
                return new TitleResponse($"Title Id not found: {id}");

            try
            {
                await _titleRepository.DeleteAsync(existingTitle).ConfigureAwait(false);
                return new TitleResponse(existingTitle);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TitleResponse($"An error occurred when deleting the title: {ex.Message}");
            }
        }

        public async Task<TitleResponse> DeleteAsync(Title title)
        {
            if (title == null)
                return new TitleResponse($"Title not found: {title}");

            try
            {
                await _titleRepository.DeleteAsync(title).ConfigureAwait(false);
                return new TitleResponse(title);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TitleResponse($"An error occurred when deleting the title: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Title>> GetAllAsync()
        {
            return await Task.Run(() => _titleRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<TitleResponse> GetByIdAsync(Guid id)
        {
            var title = await _titleRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (title == null)
                return new TitleResponse($"Title Id not found: {id}");

            return new TitleResponse(title);
        }

        public async Task<TitleResponse> UpdateAsync(Guid id, Title title)
        {
            if (title == null)
                return new TitleResponse($"Title not found: {title}");

            var existingTitle = await _titleRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingTitle == null)
                return new TitleResponse($"Title Id not found: {id}");

            existingTitle.Name = title.Name;

            try
            {
                await _titleRepository.UpdateAsync(existingTitle).ConfigureAwait(false);
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