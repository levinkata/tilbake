using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IPortfolioService
    {
        Task<PortfoliosViewModel> GetAllAsync();
        Task<PortfolioViewModel> GetAsync(Guid id);
        Task<int> AddAsync(PortfolioViewModel model);
        Task<int> UpdateAsync(PortfolioViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
