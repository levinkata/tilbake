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
    public class PortfolioExcessBuyBackService : IPortfolioExcessBuyBackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioExcessBuyBackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(PortfolioExcessBuyBackSaveResource resource)
        {
            var portfolioExcessBuyBack = _mapper.Map<PortfolioExcessBuyBackSaveResource, PortfolioExcessBuyBack>(resource);
            portfolioExcessBuyBack.Id = Guid.NewGuid();
            portfolioExcessBuyBack.DateAdded = DateTime.Now;

            _unitOfWork.PortfolioExcessBuyBacks.Add(portfolioExcessBuyBack);
            _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.PortfolioExcessBuyBacks.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioExcessBuyBackResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PortfolioExcessBuyBacks.FindAllAsync(
                                                null,
                                                r => r.OrderBy(n => n.Insurer.Name),
                                                r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioExcessBuyBack>, IEnumerable<PortfolioExcessBuyBackResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<PortfolioExcessBuyBackResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.PortfolioExcessBuyBacks.FindAllAsync(
                                                e => e.PortfolioId == portfolioId,
                                                e => e.OrderBy(r => r.Insurer.Name),
                                                e => e.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioExcessBuyBack>, IEnumerable<PortfolioExcessBuyBackResource>>(result);
            return resources;
        }

        public async Task<PortfolioExcessBuyBackResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioExcessBuyBacks.GetByIdAsync(
                                                r => r.Id == id,
                                                r => r.Insurer);

            var resource = _mapper.Map<PortfolioExcessBuyBack, PortfolioExcessBuyBackResource>(result);
            return resource;
        }

        public async void Update(PortfolioExcessBuyBackResource resource)
        {
            var portfolioExcessBuyBack = _mapper.Map<PortfolioExcessBuyBackResource, PortfolioExcessBuyBack>(resource);

            portfolioExcessBuyBack.DateModified = DateTime.Now;
            
            _unitOfWork.PortfolioExcessBuyBacks.Update(resource.Id, portfolioExcessBuyBack);
            _unitOfWork.SaveAsync();
        }
    }
}
