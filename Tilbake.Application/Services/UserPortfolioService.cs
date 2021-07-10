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
    public class UserPortfolioService : IUserPortfolioService
    {
        private readonly IUserPortfolioRepository _userPortfolioRepository;
        private readonly IMapper _mapper;

        public UserPortfolioService(IUserPortfolioRepository userPortfolioRepository, IMapper mapper)
        {
            _userPortfolioRepository = userPortfolioRepository ?? throw new ArgumentNullException(nameof(userPortfolioRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddAsync(AspnetUserPortfolioResource resource)
        {
            var aspnetUserPortfolio = _mapper.Map<AspnetUserPortfolioResource, AspnetUserPortfolio>(resource);
            return await Task.Run(() => _userPortfolioRepository.AddAsync(aspnetUserPortfolio))
                                                                .ConfigureAwait(true);
        }

        public async Task<int> AddRangeAsync(UserPortfolioResource resources)
        {
            List<AspnetUserPortfolio> aspnetUserPortfolios = new List<AspnetUserPortfolio>();

            int ro = resources.Portfolios.Length;
            var aspNetUserId = resources.UserId;
            var portfolios = resources.Portfolios;

            for (int i = 0; i < ro; i++)
            {
                AspnetUserPortfolio aspnetUserPortfolio = new AspnetUserPortfolio()
                {
                    AspNetUserId = aspNetUserId,
                    PortfolioId = Guid.Parse(portfolios[i].ToString())
                };
                aspnetUserPortfolios.Add(aspnetUserPortfolio);
            }

            return await Task.Run(() => _userPortfolioRepository.AddRangeAsync(aspnetUserPortfolios)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(AspnetUserPortfolioResource resource)
        {
            var aspnetUserPortfolio = _mapper.Map<AspnetUserPortfolioResource, AspnetUserPortfolio>(resource);
            return await Task.Run(() => _userPortfolioRepository.DeleteAsync(aspnetUserPortfolio))
                                                                .ConfigureAwait(true);
        }

        public async Task<int> DeleteRangeAsync(UserPortfolioResource resources)
        {
            List<AspnetUserPortfolio> aspnetUserPortfolios = new List<AspnetUserPortfolio>();

            int ro = resources.Portfolios.Length;
            var aspNetUserId = resources.UserId;
            var portfolios = resources.Portfolios;

            for (int i = 0; i < ro; i++)
            {
                AspnetUserPortfolio aspnetUserPortfolio = new AspnetUserPortfolio()
                {
                    AspNetUserId = aspNetUserId,
                    PortfolioId = Guid.Parse(portfolios[i].ToString())
                };
                aspnetUserPortfolios.Add(aspnetUserPortfolio);
            }

            return await Task.Run(() => _userPortfolioRepository.DeleteRangeAsync(aspnetUserPortfolios)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<AspnetUserPortfolioResource>> GetByUserIdAsync(string aspNetUserId)
        {
            var result = await Task.Run(() => _userPortfolioRepository.GetByUserIdAsync(aspNetUserId))
                                                                        .ConfigureAwait(true);

            var resources = _mapper.Map<IEnumerable<AspnetUserPortfolio>, IEnumerable<AspnetUserPortfolioResource>>(result);
            return resources;
        }
    }
}
