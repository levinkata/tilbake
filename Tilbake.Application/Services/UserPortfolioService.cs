﻿using AutoMapper;
using System;
using System.Collections.Generic;
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
            if (resources.PortfolioIds == null)
            {
                throw new ArgumentNullException(nameof(resources.PortfolioIds));
            }

            List<AspnetUserPortfolio> aspnetUserPortfolios = new List<AspnetUserPortfolio>();

            int ro = resources.PortfolioIds.Length;

            var aspNetUserId = resources.UserId;
            var portfolioIds = resources.PortfolioIds;

            for (int i = 0; i < ro; i++)
            {
                AspnetUserPortfolio aspnetUserPortfolio = new AspnetUserPortfolio()
                {
                    AspNetUserId = aspNetUserId,
                    PortfolioId = Guid.Parse(portfolioIds[i].ToString())
                };
                aspnetUserPortfolios.Add(aspnetUserPortfolio);
            }

            await _unitOfWork.UserPortfolios.AddRangeAsync(aspnetUserPortfolios);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteRangeAsync(UserPortfolioResource resources)
        {
            if (resources.PortfolioIds == null)
            {
                throw new ArgumentNullException(nameof(resources.PortfolioIds));
            }

            List<AspnetUserPortfolio> aspnetUserPortfolios = new List<AspnetUserPortfolio>();

            int ro = resources.PortfolioIds.Length;
            var aspNetUserId = resources.UserId;
            var portfolioIds = resources.PortfolioIds;

            for (int i = 0; i < ro; i++)
            {
                AspnetUserPortfolio aspnetUserPortfolio = new AspnetUserPortfolio()
                {
                    AspNetUserId = aspNetUserId,
                    PortfolioId = Guid.Parse(portfolioIds[i].ToString())
                };
                aspnetUserPortfolios.Add(aspnetUserPortfolio);
            }

            await _unitOfWork.UserPortfolios.DeleteRangeAsync(aspnetUserPortfolios);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<PortfolioResource>> GetByNotUserIdAsync(string aspNetUserId)
        {
            var result = await Task.Run(() => _unitOfWork.UserPortfolios.GetByNotUserIdAsync(aspNetUserId));
            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

            return resources;
        }

        public async Task<IEnumerable<PortfolioResource>> GetByUserIdAsync(string aspNetUserId)
        {
            var result = await Task.Run(() => _unitOfWork.UserPortfolios.GetByUserIdAsync(aspNetUserId));
            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

            return resources;
        }
    }
}
