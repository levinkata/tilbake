using AutoMapper;
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
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PortfolioSaveResource resource)
        {
            var portfolio = _mapper.Map<PortfolioSaveResource, Portfolio>(resource);
            portfolio.Id = Guid.NewGuid();
            portfolio.DateAdded = DateTime.Now;
            await _unitOfWork.Portfolios.AddAsync(portfolio);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var portfolio = await _unitOfWork.Portfolios.GetFirstOrDefaultAsync(
                                                        e => e.Id == id,
                                                        e => e.AspnetUserPortfolios);
            var aspnetUserPortfolios = portfolio.AspnetUserPortfolios;

            await _unitOfWork.UserPortfolios.DeleteRangeAsync(aspnetUserPortfolios);
            await _unitOfWork.Portfolios.DeleteAsync(portfolio);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(PortfolioResource resource)
        {
            var portfolio = _mapper.Map<PortfolioResource, Portfolio>(resource);
            await _unitOfWork.Portfolios.DeleteAsync(portfolio);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Portfolios.GetAllAsync();
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

            return resources;
        }

        public async Task<PortfolioResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Portfolios.GetByIdAsync(id);
            var resources = _mapper.Map<Portfolio, PortfolioResource>(result);
            return resources;
        }

        public async Task<int> UpdateAsync(PortfolioResource resource)
        {
            var portfolio = _mapper.Map<PortfolioResource, Portfolio>(resource);
            await _unitOfWork.Portfolios.UpdateAsync(resource.Id, portfolio);

            return await _unitOfWork.SaveAsync();
        }
    }
}