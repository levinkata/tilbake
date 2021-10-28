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

        public async void Add(PortfolioSaveResource resource)
        {
            var portfolio = _mapper.Map<PortfolioSaveResource, Portfolio>(resource);
            portfolio.Id = Guid.NewGuid();
            portfolio.DateAdded = DateTime.Now;
            _unitOfWork.Portfolios.Add(portfolio);

            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            var portfolio = await _unitOfWork.Portfolios.GetFirstOrDefaultAsync(
                                                        e => e.Id == id,
                                                        e => e.AspnetUserPortfolios);
            var aspnetUserPortfolios = portfolio.AspnetUserPortfolios;

            _unitOfWork.UserPortfolios.DeleteRange(aspnetUserPortfolios);
            _unitOfWork.Portfolios.Delete(portfolio);

            await _unitOfWork.SaveAsync();
        }

        public async void Delete(PortfolioResource resource)
        {
            var portfolio = _mapper.Map<PortfolioResource, Portfolio>(resource);
            _unitOfWork.Portfolios.Delete(portfolio);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Portfolios.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<Portfolio>, IEnumerable<PortfolioResource>>(result);

            return resources;
        }

        public async Task<PortfolioResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Portfolios.GetFirstOrDefaultAsync(
                                            r => r.Id == id,
                                            r => r.PortfolioClients);
                                            
            var resource = _mapper.Map<Portfolio, PortfolioResource>(result);
            return resource;
        }

        public async void Update(PortfolioResource resource)
        {
            var portfolio = _mapper.Map<PortfolioResource, Portfolio>(resource);
            _unitOfWork.Portfolios.Update(resource.Id, portfolio);

            await _unitOfWork.SaveAsync();
        }
    }
}