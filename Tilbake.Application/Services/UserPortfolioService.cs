﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Services
{
    public class UserPortfolioService : IUserPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserPortfolioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddRangeAsync(UserPortfolioResource resources)
        {
            if (resources == null)
            {
                throw new ArgumentNullException(nameof(resources));
            }

            List<AspnetUserPortfolio> aspnetUserPortfolios = new();

            //int ro = resources.PortfolioIds.Length;

            var aspNetUserId = resources.UserId;
            var portfolioIds = resources.PortfolioIds;

/*             for (int i = 0; i < ro; i++)
            {
                AspnetUserPortfolio aspnetUserPortfolio = new()
                {
                    AspNetUserId = aspNetUserId,
                    PortfolioId = Guid.Parse(portfolioIds[i].ToString())
                };
                aspnetUserPortfolios.Add(aspnetUserPortfolio);
            } */

            foreach (var portfolioId in portfolioIds)
            {
                AspnetUserPortfolio aspnetUserPortfolio = new()
                {
                    AspNetUserId = aspNetUserId,
                    PortfolioId = Guid.Parse(portfolioId.ToString())
                };
                aspnetUserPortfolios.Add(aspnetUserPortfolio);
            }

            await _unitOfWork.UserPortfolios.AddRangeAsync(aspnetUserPortfolios);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteRangeAsync(UserPortfolioResource resources)
        {
            if (resources == null)
            {
                throw new ArgumentNullException(nameof(resources));
            }

            List<AspnetUserPortfolio> aspnetUserPortfolios = new();

            //int ro = resources.PortfolioIds.Length;
            var aspNetUserId = resources.UserId;
            var portfolioIds = resources.PortfolioIds;

/*             for (int i = 0; i < ro; i++)
            {
                AspnetUserPortfolio aspnetUserPortfolio = new()
                {
                    AspNetUserId = aspNetUserId,
                    PortfolioId = Guid.Parse(portfolioIds[i].ToString())
                };
                aspnetUserPortfolios.Add(aspnetUserPortfolio);
            } */

            foreach (var portfolioId in portfolioIds)
            {
                AspnetUserPortfolio aspnetUserPortfolio = new()
                {
                    AspNetUserId = aspNetUserId,
                    PortfolioId = Guid.Parse(portfolioId.ToString())
                };
                aspnetUserPortfolios.Add(aspnetUserPortfolio);
            }

            await _unitOfWork.UserPortfolios.DeleteRangeAsync(aspnetUserPortfolios);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioResource>> GetByNotUserIdAsync(string aspNetUserId)
        {
/*             return await _context.Portfolios
                    .Where(c => !c.AspnetUserPortfolios
                    .Any(u => u.AspNetUserId == aspNetUserId))
                    .Include(c => c.PortfolioClients)
                    .OrderBy(n => n.Name).AsNoTracking().ToListAsync(); */

            var result = await _unitOfWork.Portfolios.GetAllAsync(
                                            r => !r.AspnetUserPortfolios
                                            .Any(r => r.AspNetUserId == aspNetUserId),
                                            r => r.OrderBy(n => n.Name),
                                            r => r.PortfolioClients);

            // var result = await  _unitOfWork.UserPortfolios.GetByNotUserIdAsync(aspNetUserId);
            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

            return resources;
        }

        public async Task<IEnumerable<PortfolioResource>> GetByUserIdAsync(string aspNetUserId)
        {
/*             return await _context.Portfolios
                                .Where(c => c.AspnetUserPortfolios
                                .Any(p => p.AspNetUserId == aspNetUserId))
                                .Include(c => c.PortfolioClients)
                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync(); */

            var result = await _unitOfWork.Portfolios.GetAllAsync(
                                            r => r.AspnetUserPortfolios
                                            .Any(r => r.AspNetUserId == aspNetUserId),
                                            r => r.OrderBy(n => n.Name),
                                            r => r.PortfolioClients);

            //var result = await _unitOfWork.UserPortfolios.GetByUserIdAsync(aspNetUserId);
            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);
            return resources;
        }
    }
}
