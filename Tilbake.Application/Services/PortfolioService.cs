using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<int> AddAsync(PortfolioViewModel model)
        {
            return await Task.Run(() => _portfolioRepository.AddAsync(model.Portfolio)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _portfolioRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<PortfoliosViewModel> GetAllAsync()
        {
            return new PortfoliosViewModel()
            {
                Portfolios = await Task.Run(() => _portfolioRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<PortfolioViewModel> GetAsync(Guid id, bool includeRelated)
        {
            return new PortfolioViewModel()
            {
                Portfolio = await Task.Run(() => _portfolioRepository.GetAsync(id, includeRelated)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(PortfolioViewModel model)
        {
            return await Task.Run(() => _portfolioRepository.UpdateAsync(model.Portfolio)).ConfigureAwait(true);
        }
    }
}
