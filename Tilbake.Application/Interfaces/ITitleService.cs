using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface ITitleService
    {
        Task<TitlesViewModel> GetAllAsync();
        Task<TitleViewModel> GetAsync(Guid id);
        Task<int> AddAsync(TitleViewModel model);
        Task<int> UpdateAsync(TitleViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}

