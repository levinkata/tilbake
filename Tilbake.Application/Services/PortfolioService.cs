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

            await _unitOfWork.Portfolios.AddAsync(portfolio).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Portfolios.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(PortfolioResource resource)
        {
            var portfolio = _mapper.Map<PortfolioResource, Portfolio>(resource);
            await _unitOfWork.Portfolios.DeleteAsync(portfolio).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<PortfolioResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Portfolios.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

            return resources;
        }

        //public async Task<IEnumerable<PortfolioResource>> GetByUserIdAsync(string aspNetUserId)
        //{
        //    var result = await Task.Run(() => _unitOfWork.Portfolios.GetByUserIdAsync(aspNetUserId)).ConfigureAwait(true);
        //    result = result.OrderBy(n => n.Name);

        //    var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

        //    return resources;
        //}

        public async Task<PortfolioResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Portfolios.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<Portfolio, PortfolioResource>(result);
            return resources;
        }

        public async Task<int> UpdateAsync(PortfolioResource resource)
        {
            var portfolio = _mapper.Map<PortfolioResource, Portfolio>(resource);
            await _unitOfWork.Portfolios.UpdateAsync(resource.Id, portfolio).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        //public async Task<IEnumerable<PortfolioResource>> GetByNotUserIdAsync(string aspNetUserId)
        //{
        //    var result = await Task.Run(() => _unitOfWork.Portfolios.GetByNotUserIdAsync(aspNetUserId)).ConfigureAwait(true);
        //    result = result.OrderBy(n => n.Name);

        //    var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

        //    return resources;
        //}
    }
}