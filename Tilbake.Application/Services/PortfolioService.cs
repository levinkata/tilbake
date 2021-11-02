using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

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
            _unitOfWork.Portfolios.Add(portfolio);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var portfolio = await _unitOfWork.Portfolios.GetAsync(
                                                        e => e.Id == id, null,
                                                        e => e.AspnetUserPortfolios);
            var aspnetUserPortfolios = portfolio.FirstOrDefault().AspnetUserPortfolios;

            _unitOfWork.UserPortfolios.DeleteRange(aspnetUserPortfolios);
            _unitOfWork.Portfolios.Delete(portfolio.FirstOrDefault().Id);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Portfolios.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

            return resources;
        }

        public async Task<PortfolioResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Portfolios.GetAsync(
                                            r => r.Id == id, null,
                                            r => r.PortfolioClients);
                                            
            var resource = _mapper.Map<Portfolio, PortfolioResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(PortfolioResource resource)
        {
            var portfolio = _mapper.Map<PortfolioResource, Portfolio>(resource);
            _unitOfWork.Portfolios.Update(resource.Id, portfolio);

            return await _unitOfWork.SaveAsync();
        }
    }
}