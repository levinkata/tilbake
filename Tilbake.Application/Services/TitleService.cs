using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;

        public TitleService(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public async Task<int> AddAsync(TitleViewModel model)
        {
            return await Task.Run(() => _titleRepository.AddAsync(model.Title)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _titleRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<TitlesViewModel> GetAllAsync()
        {
            return new TitlesViewModel()
            {
                Titles = await Task.Run(() => _titleRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<TitleViewModel> GetAsync(Guid id)
        {
            return new TitleViewModel()
            {
                Title = await Task.Run(() => _titleRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(TitleViewModel model)
        {
            return await Task.Run(() => _titleRepository.UpdateAsync(model.Title)).ConfigureAwait(true);
        }        
    }
}