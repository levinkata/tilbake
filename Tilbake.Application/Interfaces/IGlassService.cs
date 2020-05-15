using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IGlassService
    {
        Task<GlassesViewModel> GetAllAsync();
        Task<GlassViewModel> GetAsync(Guid id);
        Task<int> AddAsync(GlassViewModel model);
        Task<int> UpdateAsync(GlassViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
