using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public PortfolioService(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository ?? throw new ArgumentNullException(nameof(portfolioRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddAsync(PortfolioSaveResource resource)
        {
            var portfolio = _mapper.Map<PortfolioSaveResource, Portfolio>(resource);
            portfolio.Id = Guid.NewGuid();
            
            return await Task.Run(() => _portfolioRepository.AddAsync(portfolio)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _portfolioRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(PortfolioResource resource)
        {
            var portfolio = _mapper.Map<PortfolioResource, Portfolio>(resource);
            return await Task.Run(() => _portfolioRepository.DeleteAsync(portfolio)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<PortfolioResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _portfolioRepository.GetAllAsync()).ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

            return resources;
        }

        public async Task<IEnumerable<PortfolioResource>> GetByUserIdAsync(string aspNetUserId)
        {
            var result = await Task.Run(() => _portfolioRepository.GetByUserIdAsync(aspNetUserId)).ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

            return resources;
        }

        public async Task<PortfolioResource> GetByIdAsync(Guid id)
        {

            var result = await _portfolioRepository.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<Portfolio, PortfolioResource>(result);
            return resources;
        }

        public async Task<int> UpdateAsync(PortfolioResource resource)
        {
            var portfolio = _mapper.Map<PortfolioResource, Portfolio>(resource);
            return await Task.Run(() => _portfolioRepository.UpdateAsync(portfolio)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<PortfolioResource>> GetByNotUserIdAsync(string aspNetUserId)
        {
            var result = await Task.Run(() => _portfolioRepository.GetByNotUserIdAsync(aspNetUserId)).ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

            return resources;
        }
    }
}