using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class PortfolioClientService : IPortfolioClientService
    {
        private readonly IPortfolioClientRepository _portfolioClientRepository;
        private readonly IMapper _mapper;

        public PortfolioClientService(IPortfolioClientRepository portfolioClientRepository, IMapper mapper)
        {
            _portfolioClientRepository = portfolioClientRepository ?? throw new ArgumentNullException(nameof(portfolioClientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddAsync(PortfolioClientSaveResource resource)
        {
            var portfolioClient = _mapper.Map<PortfolioClientSaveResource, PortfolioClient>(resource);
            portfolioClient.Id = Guid.NewGuid();

            return await Task.Run(() => _portfolioClientRepository.AddAsync(portfolioClient)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _portfolioClientRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<PortfolioClientResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _portfolioClientRepository.GetAllAsync()).ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<PortfolioClient>, IEnumerable<PortfolioClientResource>>(result);

            return resources;
        }

        public async Task<PortfolioClientResource> GetByIdAsync(Guid id)
        {
            var result = await _portfolioClientRepository.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<PortfolioClient, PortfolioClientResource>(result);
            return resources;
        }
    }
}
